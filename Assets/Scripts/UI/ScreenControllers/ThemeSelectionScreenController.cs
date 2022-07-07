using UnityEngine;
using UnityEngine.UI;

using Gameplay;

public class ThemeSelectionScreenController : SelectionScreenController
{
    //public GameObject[] Buttons;

    [NonReorderable]
    public Theme[] Themes;

    public void Start()
    {
        InitButtons(Themes);
    }

    /*protected override void NameButton(GameObject button, int index)
    {
        button.name = $"Theme{index + 1}Button";
    }*/

    protected override void InitButton(GameObject button, ClassWithName classWithName)
    {
        base.InitButton(button, classWithName);
        button.GetComponent<Button>().onClick.AddListener(delegate { SelectTheme((Theme)classWithName); });
    }

    public void SelectTheme(Theme theme)
    {
        Debug.Log($"DEBUG - 22 | SelectTheme called with {theme}");
        NextScreen.GetComponent<LevelSelectionScreenController>().Init(theme);
        OpenScreen(NextScreen);
    }
}
