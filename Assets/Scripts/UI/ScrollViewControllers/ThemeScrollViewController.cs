using UnityEngine;

using Gameplay;

public class ThemeScrollViewController : ScrollViewController
{
    // NonReorderable Is only used to avoid overlap in the editor
    [NonReorderable]
    public Theme[] Themes;

    public override void Start()
    {
        base.Start();
        Init(Themes);
    }

    public void Init(Theme[] themes)
    {
        // TODO put comments
        Init(themes, theme => theme.Name, theme => delegate { SelectTheme(theme); });
    }

    protected override string NameButton(int i)
    {
        return $"Theme{i + 1}Button";
    }

    public void SelectTheme(Theme theme)
    {
        Debug.Log($"DEBUG - 22 | SelectTheme called with {theme}");
        NextScreen.GetComponent<LevelSelectionScreenController>().Init(theme);
        ScreenController.OpenScreen(NextScreen);
    }
}
