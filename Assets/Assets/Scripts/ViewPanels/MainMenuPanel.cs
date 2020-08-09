using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuPanel : BasePanel
{
    // Create a room
    public void ExtCreateRoom()
    {
        ServiceManager.ViewManager.TransitToCreateRoom();
    }

    // Join a room
    public void ExtJoinRoom()
    {
        ServiceManager.ViewManager.TransitToRoomList();        
        //ServiceManager.ViewManager.TransitToGameplay();
    }

}
