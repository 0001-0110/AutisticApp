using UnityEngine;
using TMPro;

using Gameplay;

public abstract class SelectionScreenController : ScreenController
{
    public GameObject[] Buttons;

    public GameObject NextScreen;

    /*protected virtual void NameButton(GameObject button, int index)
    {
        button.name = $"Theme{index + 1}Button";
    }*/

    protected virtual void InitButton(GameObject button, ClassWithName classWithName)
    {
        //NameButton(button, classWithName);
        button.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = classWithName.Name;
    }

    public void InitButtons(ClassWithName[] array)
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i >= array.Length)
                // This button is not needed
                Buttons[i].SetActive(false);
            else
                InitButton(Buttons[i], array[i]);
        }
    }
}
