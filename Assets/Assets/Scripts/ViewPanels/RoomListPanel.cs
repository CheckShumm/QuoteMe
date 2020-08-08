using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomListPanel : BasePanel
{
    public void extJoinRoom(uint index)
    {
        if (PhotonNetwork.IsConnected)
        {
            // join a room by name
            PhotonNetwork.JoinRoom("");
            ServiceManager.ViewManager.TransitToRoom();
        }
        else
        {
            // TODO try to reconnect to the room again
            Debug.Log("User was not connected :(");
            PhotonNetwork.ConnectUsingSettings();

        }
    }
}
