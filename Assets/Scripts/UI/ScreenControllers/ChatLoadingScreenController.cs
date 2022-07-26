using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class ChatLoadingScreenController : ScreenController
{
    public MultiplayerController MultiplayerController;
    [Tooltip("The name of the room where everyone is connected")]
    public const string PublicRoomName = "PublicRoom";

    [Tooltip("The list of all buttons that needs to be activated only after the connection is established")]
    // TODO name unclear
    public Button[] Buttons;

    public GameObject ChatScreen;

    // This async method return type is void because it is a unity message
    public async void Start()
    {
        //SetButtonsInteractable(false);
        if (await MultiplayerController.ConnectToMaster())
        {
            RoomOptions roomOptions = new RoomOptions();
            if (await MultiplayerController.JoinOrCreateRoom(PublicRoomName, roomOptions))
                //SetButtonsInteractable(true);
                OpenScreen(ChatScreen);
        }
    }

    public override void OpenScreen(GameObject screen)
    {
        StopAllCoroutines();
        base.OpenScreen(screen);
    }

    public void SetButtonsInteractable(bool interactable)
    {
        foreach (Button button in Buttons)
            button.interactable = interactable;
    }
}
