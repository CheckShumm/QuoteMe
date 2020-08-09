using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Photon.Pun;

public class RoomManager
{
    private List<Room> _rooms = null;

    public static void Initialize()
    {
        ServiceManager.RoomManager = new RoomManager();
        ServiceManager.RoomManager._rooms = new List<Room>();
    }

    public List<Room> GetRooms()
    {
        return _rooms;
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
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


}