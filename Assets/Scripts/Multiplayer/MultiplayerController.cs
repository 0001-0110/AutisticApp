using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerController : MonoBehaviourPunCallbacks
{
    [Tooltip("Delay before time out (ms)")]
    public int TimeOut;

    public bool IsConnectedToMaster { get; private set; }
    public bool IsConnectedToLobby { get; private set; }
    public bool IsConnectedToRoom { get; private set; }

    public Dictionary<int, Player> Players => PhotonNetwork.CurrentRoom.Players;

    public void Start()
    {
        IsConnectedToMaster = false;
        IsConnectedToLobby = false;
        IsConnectedToRoom = false;
    }

    public override void OnConnectedToMaster()
    {
        IsConnectedToMaster = true;
    }

    public override void OnJoinedLobby()
    {
        IsConnectedToLobby = true;
    }

    public override void OnLeftLobby()
    {
        IsConnectedToLobby = false;
    }

    public override void OnJoinedRoom()
    {
        IsConnectedToRoom = true;
    }

    public override void OnLeftRoom()
    {
        IsConnectedToRoom = false;
    }

    private async Task<bool> WaitForConnectedToMaster()
    {
        while (!IsConnectedToMaster) 
            await Task.Delay(1);
        return true;
    }

    private async Task<bool> WaitForConnectedToLobby()
    {
        while (!IsConnectedToLobby)
            await Task.Delay(1);
        return true;
    }

    private async Task<bool> WaitForConnectedToRoom()
    {
        while (!IsConnectedToRoom)
            await Task.Delay(1);
        return true;
    }

    public async Task<bool> ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
        // Wait for the connection to be established or the time out to be reached
        await Task.WhenAny(WaitForConnectedToMaster(), Task.Delay(TimeOut));
        return PhotonNetwork.IsConnectedAndReady;
    }

    public async Task<bool> ConnectToLobby()
    {
        PhotonNetwork.JoinLobby();
        // Wait for the connection to be established or the time out to be reached
        await Task.WhenAny(WaitForConnectedToLobby(), Task.Delay(TimeOut));
        return PhotonNetwork.InLobby;
    }

    public async Task<bool> JoinOrCreateRoom(string roomName, RoomOptions roomOptions, string[] expectedUsers = null)
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default, expectedUsers);
        // Wait for the connection to be established or the time out to be reached
        await Task.WhenAny(WaitForConnectedToRoom(), Task.Delay(TimeOut));
        return PhotonNetwork.InRoom;
    }
}
