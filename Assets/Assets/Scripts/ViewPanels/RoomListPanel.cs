using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListPanel : BasePanel
{
    [SerializeField] private RoomItem _roomItem = null;
    [SerializeField] private ScrollRect _roomScroll = null;
    private List<RoomItem> _roomItemList = new List<RoomItem>();

    private void Start() 
    {
        // Destroy any existing children in scroll rect
        foreach(Transform child in _roomScroll.content.transform) 
        {
            Destroy(child.gameObject);
        }
        ServiceManager.RoomManager.RoomListUpdated += UpdateRooms;
    }

    private void Destroy() 
    {
        ServiceManager.RoomManager.RoomListUpdated -= UpdateRooms;
    }

    protected override void OnActive()
    {
        UpdateRooms();
    }

    public void UpdateRooms()
    {
        ClearRooms();
        IEnumerable<RoomInfo> rooms = ServiceManager.RoomManager.GetRooms();
        int i = 0;
        foreach(RoomInfo room in rooms) 
        {
            if ( i < _roomItemList.Count)
            {
                _roomItemList[i].Initialize(room.Name, room.PlayerCount, room.MaxPlayers, "TODO");
            }
            else 
            {
                RoomItem roomItem = Instantiate(_roomItem, _roomScroll.content);
                roomItem.Initialize(room.Name, room.PlayerCount, room.MaxPlayers, "TODO");
                _roomItemList.Add(roomItem);
            }
            i++;
        }
    }

    private void ClearRooms()
    {
        _roomItemList.RemoveAll(room => room == null);
        foreach (RoomItem roomitem in _roomItemList)
        {
            roomitem.gameObject.SetActive(false);
        }
    }
}
