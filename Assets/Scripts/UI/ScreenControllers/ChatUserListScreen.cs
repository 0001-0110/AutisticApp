using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class ChatUserListScreen : ScreenController
{
    [Tooltip("The gameObject used to display one user")]
    public GameObject UserProfilePrefab;

    private MultiplayerController multiplayerController;

    public GameObject UserScrollView;
    private GameObject content;
    private List<GameObject> playerInfos;

    public void Awake()
    {
        multiplayerController = GameObject.Find("MultiplayerController").GetComponent<MultiplayerController>();
        content = UserScrollView.transform.Find("Viewport").Find("Content").gameObject;
        playerInfos = new List<GameObject>();
    }

    public void OnEnable()
    {
        RefreshPlayerInfos();
    }

    private void RefreshPlayerInfos()
    {
        // Clear all previous player infos
        foreach (GameObject playerInfo in playerInfos)
            Destroy(playerInfo);

        if (multiplayerController.Players.Count == 0)
        {
            // TODO you have no friends
        }

        foreach (Player player in multiplayerController.Players.Values)
        {
            if (player != multiplayerController.LocalPlayer)
            {
                GameObject newPlayerInfo = Instantiate(UserProfilePrefab, content.transform);
                newPlayerInfo.GetComponent<UserInfoController>().InitUserInfo(player.NickName);
                playerInfos.Add(newPlayerInfo);
            }
        }
    }
}
