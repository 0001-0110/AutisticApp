using UnityEngine;

using Gameplay;

public class GameScreenController : ScreenController
{
    public GameController gameController;
    public GameObject QuestionScreen;

    private Level Level;

    public void Init(Level level)
    {
        Level = level;
        gameController.InitWebView(Level.Url);
    }

    public override void OpenScreen(GameObject screen)
    {
        Debug.Log("DEBUG - 22 | destroying the webView");
        gameController.DestroyWebView();
        base.OpenScreen(screen);
    }

    public void OpenQuestion()
    {
        QuestionScreen.GetComponent<QuestionScreenController>().Init(Level.Question);
        OpenScreen(QuestionScreen);
    }
}
