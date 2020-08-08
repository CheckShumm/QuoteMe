using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenuPanel : BasePanel
{

   public void ExtPlay()
   {
       ServiceManager.ViewManager.TransitToGameplay();
   }

    // Create a room
    private void ExtCreateRoom(string roomName)
    {
        Debug.Log("created room " + roomName);
        PhotonNetwork.CreateRoom(roomName);
        ServiceManager.ViewManager.TransitToRoom();
    }

}
