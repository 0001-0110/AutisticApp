using Gameplay;

public class GameScreenController : ScreenController
{
    public GameController gameController;

    public void Init(Level level)
    {
        gameController.InitWebView(level.Url);
    }
}
