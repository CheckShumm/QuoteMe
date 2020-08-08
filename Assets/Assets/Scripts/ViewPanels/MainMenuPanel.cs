using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuPanel : BasePanel
{
    // Create a room
    private void ExtCreateRoom()
    {
        ServiceManager.ViewManager.TransitToCreateRoom();
    }

    // Join a room
    private void ExtJoinRoom()
    {
        ServiceManager.ViewManager.TransitToRoomList();
    }

}
