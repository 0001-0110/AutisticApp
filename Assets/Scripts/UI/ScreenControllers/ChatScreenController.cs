using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class ChatScreenController : ScreenController
{
    private MultiplayerController multiplayerController;

    public GameObject SenderChatMessagePrefab;
    public GameObject ReceiverChatMessagePrefab;

    private PhotonView photonView;

    public ScrollRect ScrollRect;
    public TMP_InputField MessageInput;
    private GameObject ChatContent;

    public void Start()
    {
        multiplayerController = MultiplayerController.Instance;

        photonView = GetComponent<PhotonView>();

        ChatContent = transform.Find("MessageScrollView").Find("Viewport").Find("Content").gameObject;

        //RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
    }

    public IEnumerator DisplayChatMessage(string userName, string message, bool sender = false)
    {
        GameObject chatMessagePrefab = sender ? SenderChatMessagePrefab : ReceiverChatMessagePrefab;
        GameObject ChatMessage = Instantiate(chatMessagePrefab, ChatContent.transform);
        ChatMessage.GetComponent<ChatMessageController>().InitMessage(userName, message);
        // Wait for one frame
        // If we don't wait for at least one frame, the last message is ignored when scrolling down
        yield return null;
        // Scroll to the bottom of the chat
        ScrollRect.normalizedPosition = Vector2.zero;
        yield break;
    }

    public void SendChatMessage()
    {
        Debug.Log($"DEBUG - 22 | Message sent: {MessageInput.text}");
        // send message to others
        photonView.RPC("ReceiveChatMessage", RpcTarget.Others, multiplayerController.LocalPlayer.NickName, MessageInput.text);
        // display my own message
        StartCoroutine(DisplayChatMessage(multiplayerController.LocalPlayer.NickName, MessageInput.text, true));
        // Clear the input
        MessageInput.text = string.Empty;
    }

    [PunRPC]
    public void ReceiveChatMessage(string userName, string message)
    {
        Debug.Log($"DEBUG - 22 | Message received: {message}");
        StartCoroutine(DisplayChatMessage(userName, message, false));
    }

    public void ExitChat(GameObject screen)
    {
        PhotonNetwork.LeaveRoom();
        OpenScreen(screen);
    }
}
