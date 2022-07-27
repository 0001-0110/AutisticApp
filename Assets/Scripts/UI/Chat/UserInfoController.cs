using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UserInfoController : MonoBehaviour, IPointerDownHandler
{
    private GameObject userProfilePicture;
    private GameObject userInfo;
    private TextMeshProUGUI userNameText;

    public void Awake()
    {
        userProfilePicture = transform.Find("UserProfilePicture").gameObject;
        userInfo = transform.Find("UserInfo").gameObject;
        userNameText = userInfo.transform.Find("UserName").GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PRESSED");
    }

    public void InitUserInfo(string userName)
    {
        userNameText.text = userName;
    }
}
