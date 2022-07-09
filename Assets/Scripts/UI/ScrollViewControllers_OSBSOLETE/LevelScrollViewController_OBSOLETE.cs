using UnityEngine;

using Gameplay;

public class LevelScrollViewController : ScrollViewController
{
    //public Level[] Levels;

    public override void Start()
    {
        base.Start();
    }

    public void Init(Level[] levels)
    {
        // TODO put comments
        Init(levels, level => level.Name, level => delegate { SelectLevel(level); });
    }

    protected override string NameButton(int i)
    {
        return $"Level{i + 1}Button";
    }

    public void SelectLevel(Level level)
    {
        Debug.Log($"DEBUG - 22 | SelectLevel called with {level}");
        NextScreen.GetComponent<QuestionScreenController>().Init(level.Question);
        ScreenController.OpenScreen(NextScreen);
    }
}
