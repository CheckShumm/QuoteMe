using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using WebSocketSharp;

public class CreateRoomPanel : BasePanel
{

    [SerializeField] private TMP_InputField _roomNameInput = null;
    [SerializeField] private TMP_InputField _roomPasswordInput = null;

    public void CreateRoom()
    {
       
        string roomName = _roomNameInput.text; 

        // TODO UI feedback ("Dont put spaces...")
        if (roomName.IsNullOrEmpty() || roomName.Contains(" "))
            return;

        Room room = new Room(roomName);
        
        Debug.Log("creating room " + roomName);
        PhotonNetwork.CreateRoom(room.getID());
        ServiceManager.ViewManager.TransitToRoom();
    }

    protected override void OnBack()
    {
        ServiceManager.ViewManager.TransitToRoomList();
    }
}
