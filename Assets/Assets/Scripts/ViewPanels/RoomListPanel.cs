using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class RoomListPanel : BasePanel
{
    [SerializeField] private RoomItem _roomItem = null;
    [SerializeField] private ScrollRect _roomList = null;
    private List<RoomItem> _roomItemList = new List<RoomItem>();

    protected override void OnActivate()
    {
        UpdateRooms();
    }

    public void UpdateRooms()
    {   

        List<Room> rooms = ServiceManager.RoomManager.GetRooms();
        for (int i = 0; i < rooms.Count; i++) {
            Room room = rooms[i];

            if ( i < _roomItemList.Count)
                _roomItemList[i].Initialize(room.getName(), room.getPlayerCount(), room.getHostName());
            else 
                Instantiate(_roomItem, _roomList.content).Initialize(room.getName(), room.getPlayerCount(), room.getHostName());
        }
    }

    public void clearRooms()
    {
        foreach (RoomItem roomitem in _roomItemList){
            // deactive items
        }

    }

}
