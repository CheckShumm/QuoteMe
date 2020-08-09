using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
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

    public void JoinRoom(Room room, string password)
    {
        // TODO validate password with a popup
        
        if (PhotonNetwork.IsConnected)
        {
            // join a room by name
            PhotonNetwork.JoinRoom("");
            ServiceManager.ViewManager.TransitToRoom();
            room.AddPlayer(ServiceManager.PlayerManager.LocalPlayerProfile);
        }
        else
        {
            // TODO try to reconnect to the room again
            Debug.Log("User was not connected :(");
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateCachedRooms(roomList);
    }
}