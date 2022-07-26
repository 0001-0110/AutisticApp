using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInfoController : MonoBehaviour
{
    private GameObject userProfilePicture;
    private GameObject userInfo;
    private TextMeshProUGUI userNameText;

    void Awake()
    {
        userProfilePicture = transform.Find("UserProfilePicture").gameObject;
        userInfo = transform.Find("UserInfo").gameObject;
        userNameText = userInfo.transform.Find("UserName").GetComponent<TextMeshProUGUI>();
    }

    public void InitUserInfo(string userName)
    {
        userNameText.text = userName;
    }
}
