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
        ServiceManager.RoomManager.CreateRoom(roomName, password);
    }

    public void ExtOnBack()
    {
        ServiceManager.ViewManager.TransitToMainMenu();
    }
}
