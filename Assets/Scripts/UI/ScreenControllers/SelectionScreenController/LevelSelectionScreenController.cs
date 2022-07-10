using UnityEngine;
using UnityEngine.UI;

using Gameplay;

public class LevelSelectionScreenController : SelectionScreenController
{
    //public LevelScrollViewController LevelScrollViewController;

    /*protected override void NameButton(GameObject button, int index)
    {
        button.name = $"Level{index + 1}Button";
    }*/

    public void Init(Theme theme)
    {
        //LevelScrollViewController.Init(theme.Levels);
        InitButtons(theme.Levels);
    }

    protected override void InitButton(GameObject button, ClassWithName classWithName)
    {
        base.InitButton(button, classWithName);
        button.GetComponent<Button>().onClick.AddListener(delegate { SelectLevel((Level)classWithName); });
    }

    public void SelectLevel(Level level)
    {
        Debug.Log($"DEBUG - 22 | SelectLevel called with {level}");
        // This needs to be before Init, because coroutines need the gameObject to be active
        OpenScreen(NextScreen);
        NextScreen.GetComponent<GameScreenController>().Init(level);
    }
}
