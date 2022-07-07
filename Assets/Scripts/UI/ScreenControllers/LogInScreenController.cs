using TMPro;

public class LogInScreenController : ConnectionScreenController
{
    public TMP_InputField IDInput;
    public TMP_InputField PasswordInput;

    protected override bool IsInputValid()
    {
        return IDInput.text != string.Empty && PasswordInput.text != string.Empty;
    }
}
