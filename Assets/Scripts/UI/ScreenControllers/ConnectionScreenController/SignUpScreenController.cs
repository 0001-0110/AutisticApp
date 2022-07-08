using TMPro;

public class SignUpScreenController : ConnectionScreenController
{
    public TMP_InputField UsernameInput;
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField PasswordConfirmationInput;

    protected override bool IsInputValid()
    {
        return UsernameInput.text != string.Empty && EmailInput.text != string.Empty && PasswordInput.text != string.Empty && PasswordConfirmationInput.text != string.Empty;
    }
}
