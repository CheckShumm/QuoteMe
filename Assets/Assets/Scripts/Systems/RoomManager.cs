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

    public static void Initialize()
    {
        DontDestroyOnLoad(new GameObject("RoomManager", typeof(RoomManager)));
    }

    private void Start() 
    {
        ServiceManager.RoomManager = this;
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