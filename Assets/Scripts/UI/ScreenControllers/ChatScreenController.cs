using UnityEngine;
using Photon.Pun;
using TMPro;

public class ChatScreenController : ScreenController
{
    public TMP_InputField MessageInput;

    private PhotonView photonView;

    public GameObject ChatMenuScreen;

    public void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public void SendChatMessage()
    {
        Debug.Log($"DEBUG - 22 | Message sent: {MessageInput.text}");
        photonView.RPC("ReceiveChatMessage", RpcTarget.Others, MessageInput.text);
        // TODO display my own message
        // Clear the input
        MessageInput.text = string.Empty;
    }

    [PunRPC]
    public void ReceiveChatMessage(string message)
    {
        Debug.Log($"DEBUG - 22 | Message received: {message}");
        // TODO display the received message
    }

    public void ExitChat()
    {
        PhotonNetwork.LeaveRoom();
        OpenScreen(ChatMenuScreen);
    }
}
