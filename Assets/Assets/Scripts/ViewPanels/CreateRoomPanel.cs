using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class CreateRoomPanel : BasePanel
{

    [SerializeField] private TMP_InputField _roomNameInput = null;
    [SerializeField] private TMP_InputField _roomPasswordInput = null;

    public void CreateRoom()
    {
       
        string roomName = _roomNameInput.text; 
        string password = _roomPasswordInput.text;

        // TODO UI feedback ("Dont put spaces...")
        if (string.IsNullOrEmpty(roomName) || roomName.Contains(" "))
            return;

        Room room = new Room(roomName, ServiceManager.PlayerManager.LocalPlayerProfile);
        room.setPassword(password);
        Debug.Log("creating room " + roomName);
        PhotonNetwork.CreateRoom(room.Uid);//, new Photon.Realtime.RoomOptions() { MaxPlayers = 8 });
        ServiceManager.ViewManager.TransitToRoomList();
    }

    protected override void OnBack()
    {
        ServiceManager.ViewManager.TransitToRoomList();
    }
}
