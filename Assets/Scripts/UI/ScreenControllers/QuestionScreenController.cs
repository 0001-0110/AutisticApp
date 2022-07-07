using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using Gameplay;

public class QuestionScreenController : ScreenController
{
    public TextMeshProUGUI QuestionText;
    public TMP_Dropdown QuestionDropdown;
    public Button ValidateButton;
    private TextMeshProUGUI validateButtonText;

    public string InvalidText;

    private int correctAnswer;

    public void Start()
    {
        validateButtonText = ValidateButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Init(Question question)
    {
        SetText(question);
        SetOptions(question);
    }

    private void SetText(Question question)
    {
        QuestionText.text = question.QuestionString;
    }

    private void SetOptions(Question question)
    {
        QuestionDropdown.ClearOptions();
        correctAnswer = Random.Range(0, question.OtherOptions.Length + 1);
        List<string> options = new List<string>();
        for ((int i, int j) = (0, 0); i < question.OtherOptions.Length + 1; i++)
        {
            if (i == correctAnswer)
                options.Add(question.Answer);
            else
            {
                options.Add(question.OtherOptions[j]);
                j++;
            }
        }
        QuestionDropdown.AddOptions(options);
    }

    private async void IncorrectAnswer(int delay = 2000)
    {
        ValidateButton.interactable = false;
        string previousText = validateButtonText.text;
        validateButtonText.text = InvalidText;
        await Task.Delay(delay);
        validateButtonText.text = previousText;
        ValidateButton.interactable = true;
    }

    public void Validate()
    {
        if (QuestionDropdown.value != correctAnswer)
            IncorrectAnswer();
        else
        {

        }
    }
}
