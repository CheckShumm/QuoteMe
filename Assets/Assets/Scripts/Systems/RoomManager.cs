using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static readonly string RoomNameKey = "RoomName";
    public static readonly string PasswordKey = "Password";
    public static readonly string HostNameKey = "HostName";

    private Dictionary<string, RoomInfo> _rooms = new Dictionary<string, RoomInfo>();

    public Action RoomListUpdated;

    public static void Initialize()
    {
        DontDestroyOnLoad(new GameObject("RoomManager", typeof(RoomManager)));
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to photon network");
            PhotonNetwork.GameVersion = AppManager.GameVersion;
            //Set nickname
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private void Start() 
    {
        ServiceManager.RoomManager = this;
    }

    public override void OnConnectedToMaster() 
    {
        Debug.Log("PhotonNetwork: Connected to master");
        PhotonNetwork.JoinLobby();        
    }

    public IEnumerable<RoomInfo> GetRooms()
    {
        return _rooms.Values;
    }

    public void UpdateCachedRooms(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                _rooms.Remove(info.Name);
            }
            else
            {
                _rooms[info.Name] = info;
            }
        }
        RoomListUpdated?.Invoke();
    }

    public void JoinRoom(string room, string password = "")
    {
        // TODO validate password with a popup
        
        if (PhotonNetwork.IsConnected)
        {
            // join a room by name
            PhotonNetwork.JoinRoom(room);
            ServiceManager.ViewManager.TransitToRoom();
        }
        else
        {
            // TODO try to reconnect to the room again
            Debug.Log("User was not connected :(");
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public void CreateRoom(string roomName, string password="")
    {
        Debug.Log("creating room " + roomName);
        Hashtable roomProperties = new Hashtable() {
            {RoomNameKey, roomName},
            {HostNameKey, ServiceManager.PlayerManager.LocalPlayerProfile.PlayerName},
            {PasswordKey, password}
        };
        string[] lobbyProperties = {RoomNameKey, HostNameKey, PasswordKey};
        PhotonNetwork.CreateRoom(System.Guid.NewGuid().ToString(), new Photon.Realtime.RoomOptions() { 
            MaxPlayers = 8,
            CustomRoomProperties = roomProperties,
            CustomRoomPropertiesForLobby = lobbyProperties,
        });
        ServiceManager.ViewManager.TransitToRoom();
    }

    public override void OnJoinedLobby() 
    {
        Debug.Log("Photon Network: Joined Lobby");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"Photon Network: Updated room list - {roomList.Count}");
        UpdateCachedRooms(roomList);
    }
}