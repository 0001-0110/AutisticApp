using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;

public class MultiplayerController : MonoBehaviourPunCallbacks
{
    private const string PublicChatRoomName = "PublicChat";

    public ChatMenuScreenController ChatMenuScreenController;

    [Tooltip("The delay in ms between each refresh of the page (in ms)")]
    public int RefreshDelay;

    public async void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        // TODO some comments would be nice
        if (RefreshDelay <= 0)
            Debug.LogWarning($"RefreshDelay is set to {RefreshDelay}, and this can cause errors or crashes");
        while (await Refresh()) { }
    }

    /// <summary>
    /// Connected to the master server
    /// </summary>
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    /// <summary>
    /// Executes once I joined the main lobby
    /// </summary>
    public override void OnJoinedLobby()
    {
        ChatMenuScreenController.SetButtonsInteractable(true);
    }

    /// <summary>
    /// If succesfully joined the chat room, switch to the chat screen to display the chat
    /// </summary>
    public override void OnJoinedRoom()
    {
        Debug.Log("DEBUG - 22 | OnJoinRoom called");
        ChatMenuScreenController.OpenChat();
    }

    /// <summary>
    /// If we couldn't join the room we were looking for
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("DEBUG - 22 | OnJoinRoomFailed called");
        // TODO change that if you want to connect to something else than the public chat
        PhotonNetwork.CreateRoom(PublicChatRoomName);
    }

    public void JoinPublicChat()
    {
        // Try to connect to the room with this name
        // If no room is found, will call OnJoinRoomFailed
        // Else, will call OnJoinRoom
        PhotonNetwork.JoinRoom(PublicChatRoomName);
    }

    private async Task<bool> Refresh()
    {
        await Task.Delay(RefreshDelay);
        // TODO Refresh server infos
        return true;
    }
}
