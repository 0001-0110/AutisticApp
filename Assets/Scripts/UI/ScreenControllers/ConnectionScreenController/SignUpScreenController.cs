using TMPro;

public class SignUpScreenController : ConnectionScreenController
{
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordConfirmationInput;

    protected override bool IsInputValid()
    {
        return UserNameInput.text != string.Empty && EmailInput.text != string.Empty && PasswordInput.text != string.Empty && PasswordConfirmationInput.text != string.Empty;
    }
}
