using UnityEngine;
using TMPro;

public class ChatMessageController : MonoBehaviour
{
    private GameObject user;
    private TextMeshProUGUI text;

    public void Awake()
    {
        // This needs to be in Awake and not Start because the message is set at the same frame the message object is created
        text = transform.Find("Bubble").Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void InitMessage(string message)
    {
        text.text = message;
    }
}
