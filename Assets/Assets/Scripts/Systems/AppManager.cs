using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AppManager : BaseManager
{
    private const string gameVersion = "0.0.1"; 

    protected override void RegisterManager() { ServiceManager.AppManager = this; }

    private void Start() 
    {
        // connect to photon
        Connect();

        PlayerManager.Initialize();
        RoomManager.Initialize();
        DontDestroyOnLoad(new GameObject("ChatManager", typeof(ChatManager)));
    }

    // connects user to photon network
    private void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Connecting to photon network");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
}
