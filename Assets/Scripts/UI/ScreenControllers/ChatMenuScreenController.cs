using UnityEngine;
using UnityEngine.UI;

public class ChatMenuScreenController : ScreenController
{
    [Tooltip("The list of all buttons that needs to be activated only after the connection is established")]
    public Button[] Buttons;

    public GameObject ChatScreen;

    public void Start()
    {
        SetButtonsInteractable(false);
    }

    public void OpenChat()
    {
        OpenScreen(ChatScreen);
    }

    public void SetButtonsInteractable(bool interactable)
    {
        foreach (Button button in Buttons)
            button.interactable = interactable;
    }
}
