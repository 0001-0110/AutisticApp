using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public abstract class ConnectionScreenController : ScreenController
{
    public TextMeshProUGUI ButtonText;
    public GameObject NextScreen;

    public string InvalidText;

    public TMP_InputField UserNameInput;
    public TMP_InputField PasswordInput;
    private TMP_InputField[] inputFields;

    private MultiplayerController multiplayerController;

    public virtual void Awake()
    {
        inputFields = GetComponentsInChildren<TMP_InputField>(true);
        multiplayerController = GameObject.Find("MultiplayerController").GetComponent<MultiplayerController>();
    }

    public virtual void OnEnable()
    {
        ResetInputFields();
    }

    protected virtual void ResetInputFields()
    {
        foreach (TMP_InputField inputField in inputFields)
            inputField.text = string.Empty;
    }

    protected virtual bool IsInputValid()
    {
        return true;
    }

    protected async void InvalidInput(int delay = 2000)
    {
        string previousText = ButtonText.text;
        ButtonText.text = InvalidText;
        await Task.Delay(delay);
        ButtonText.text = previousText;
    }

    public virtual void Validate()
    {
        if (!IsInputValid())
            InvalidInput();
        else
        {
            multiplayerController.LocalPlayer.NickName = UserNameInput.text;
            OpenScreen(NextScreen);
        }
    }
}
