using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerController : MonoBehaviourPunCallbacks
{
    public static MultiplayerController Instance { get; private set; }

    /// <summary>
    /// Delay before time out (ms)
    /// </summary>
    /// <remarks>
    /// <para>A short timeOutDelay can stop a succesful connection</para>
    /// <para>2000 already proved to be too little</para>
    /// </remarks>
    private const int TimeOutDelay = 5000;

    /// <summary>
    /// Default time between each check
    /// </summary>
    /// <remarks>
    /// <para>A tick too short might create some performance issués</para>
    /// </remarks>
    private const int defaultTick = 250;

    public bool IsConnectedToMaster { get; private set; }
    public bool IsConnectedToLobby { get; private set; }
    public bool IsConnectedToRoom { get; private set; }

    public int PlayerCountInRooms => PhotonNetwork.CountOfPlayersInRooms;
    public int PlayerCountInLobby => PhotonNetwork.CountOfPlayersOnMaster;
    public List<RoomInfo> RoomInfos { get; private set; }
    public Room CurrentRoom => PhotonNetwork.CurrentRoom;
    public Player LocalPlayer => PhotonNetwork.LocalPlayer;
    public Dictionary<int, Player> Players => PhotonNetwork.CurrentRoom.Players;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("WHY IS THERE MULTIPLE MULTIPLAYERCONTROLLERS YOU DONUT");
        }
        Instance = this;
    }

    /// <summary>
    /// TODO doesn't work
    /// There is a bug when leaving the app while in room
    /// </summary>
    public void OnApplicationQuit()
    {
        if (PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();
    }

    #region PUNCALLBACKS

    public override void OnConnectedToMaster() => IsConnectedToMaster = true;

    public override void OnDisconnected(DisconnectCause cause) => IsConnectedToMaster = false;

    public override void OnJoinedLobby() => IsConnectedToLobby = true;

    public override void OnLeftLobby() => IsConnectedToLobby = false;

    public override void OnJoinedRoom() => IsConnectedToRoom = true;

    public override void OnLeftRoom() => IsConnectedToRoom = false;

    #endregion

    public string CreateRoomName()
    {
        throw new System.NotImplementedException();
    }

    #region FINDANAME

    public async Task<bool> ConnectToMaster(int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.ConnectUsingSettings();
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToMaster)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToMaster is {IsConnectedToMaster}");
        return IsConnectedToMaster;
    }

    public async Task<bool> DisconnectFromMaster(int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.Disconnect();
        while (timeOut > 0 && IsConnectedToMaster)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToMaster is {IsConnectedToMaster}");
        return !IsConnectedToMaster;
    }

    public async Task<bool> ConnectToLobby(int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.JoinLobby();
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToLobby)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToLobby is {IsConnectedToLobby}");
        return IsConnectedToLobby;
    }

    public async Task<bool> CreateRoom(string roomName, RoomOptions roomOptions = null, TypedLobby typedLobby = null, string[] expectedUsers = null, int timeOut = TimeOutDelay, int tick = 1)
    {
        PhotonNetwork.CreateRoom(roomName, roomOptions, typedLobby, expectedUsers);
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToRoom)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToRoom is {IsConnectedToRoom}");
        return IsConnectedToRoom;
    }

    public async Task<bool> JoinOrCreateRoom(string roomName, RoomOptions roomOptions = null, TypedLobby typedLobby = null, string[] expectedUsers = null, int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, typedLobby, expectedUsers);
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToRoom)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToRoom is {IsConnectedToRoom}");
        return IsConnectedToRoom;
    }

    public async Task<bool> JoinRandomOrCreateRoom(int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToRoom)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToRoom is {IsConnectedToRoom}");
        return IsConnectedToRoom;
    }

    public async Task<bool> JoinRoom(string roomName, string[] expectedUsers = null, int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.JoinRoom(roomName, expectedUsers);
        // Wait for the connection to be established or the time out to be reached
        while (timeOut > 0 && !IsConnectedToRoom)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToRoom is {IsConnectedToRoom}");
        return IsConnectedToRoom;
    }

    // TODO Leave room
    public async Task<bool> LeaveRoom(int timeOut = TimeOutDelay, int tick = defaultTick)
    {
        PhotonNetwork.LeaveRoom();
        // Wait for the connection to be terminated or the time out to be reached
        while (timeOut > 0 && IsConnectedToRoom)
        {
            await Task.Delay(tick);
            timeOut -= tick;
        }
        Debug.Log($"IsConnectedToRoom is {IsConnectedToRoom}");
        return !IsConnectedToRoom;
    }

    #endregion
}
