using UnityEngine;
using Photon.Pun;
using TMPro;

public class ChatScreenController : ScreenController
{
    public GameObject SenderChatMessagePrefab;
    public GameObject ReceiverChatMessagePrefab;

    private PhotonView photonView;

    public TMP_InputField MessageInput;
    private GameObject ChatContent;

    public GameObject ChatMenuScreen;

    public void Start()
    {
        photonView = GetComponent<PhotonView>();

        ChatContent = transform.Find("MessageScrollView").Find("Viewport").Find("Content").gameObject;

        //RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
    }

    public void DisplayChatMessage(string message, bool sender = false)
    {
        GameObject chatMessagePrefab = sender ? SenderChatMessagePrefab : ReceiverChatMessagePrefab;
        GameObject ChatMessage = Instantiate(chatMessagePrefab, ChatContent.transform);
        ChatMessage.GetComponent<ChatMessageController>().InitMessage(message);
    }

    public void SendChatMessage()
    {
        Debug.Log($"DEBUG - 22 | Message sent: {MessageInput.text}");
        // send message to others
        photonView.RPC("ReceiveChatMessage", RpcTarget.Others, MessageInput.text);
        // display my own message
        DisplayChatMessage(MessageInput.text, true);
        // Clear the input
        MessageInput.text = string.Empty;
    }

    [PunRPC]
    public void ReceiveChatMessage(string message)
    {
        Debug.Log($"DEBUG - 22 | Message received: {message}");
        DisplayChatMessage(message, false);
    }

    public void ExitChat()
    {
        PhotonNetwork.LeaveRoom();
        OpenScreen(ChatMenuScreen);
    }
}
