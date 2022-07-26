public class LogInScreenController : ConnectionScreenController
{
    protected override bool IsInputValid()
    {
        return UserNameInput.text != string.Empty && PasswordInput.text != string.Empty;
    }
}
