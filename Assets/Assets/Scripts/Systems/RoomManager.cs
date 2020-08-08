using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager
{
    private List<Room> _rooms = null;

    public static void Initialize()
    {
        ServiceManager.RoomManager = new RoomManager();
        ServiceManager.RoomManager._rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public void JoinRoom(Room room, string password)
    {

    }


}