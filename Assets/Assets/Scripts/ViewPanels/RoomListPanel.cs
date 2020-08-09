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

    public void ExtOnBack() 
    {
        ServiceManager.ViewManager.TransitToMainMenu();
    }

    private void Start() 
    {
        ServiceManager.RoomManager.RoomListUpdated += UpdateRooms;
    }

    private void Destroy() 
    {
        ServiceManager.RoomManager.RoomListUpdated -= UpdateRooms;
    }

    protected override void OnActivate()
    {
        UpdateRooms();
    }

    public void UpdateRooms()
    {
        ClearRooms();
        IEnumerable<RoomInfo> rooms = ServiceManager.RoomManager.GetRooms();
        Debug.Log($"RoomListPanel: Updating room list");
        int i = 0;
        foreach(RoomInfo room in rooms) 
        {
            string roomName = room.CustomProperties[RoomManager.RoomNameKey] as string;
            string hostName = room.CustomProperties[RoomManager.HostNameKey] as string;
            if ( i < _roomItemList.Count)
            {
                _roomItemList[i].Initialize(roomName, room.PlayerCount, room.MaxPlayers, hostName);
            }
            else 
            {
                RoomItem roomItem = Instantiate(_roomItem, _roomScroll.content);
                roomItem.Initialize(roomName, room.PlayerCount, room.MaxPlayers, hostName);
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
