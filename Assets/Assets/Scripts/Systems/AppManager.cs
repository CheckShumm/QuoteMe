using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AppManager : BaseManager
{
    public const string GameVersion = "1.0.0"; 

    protected override void RegisterManager() { ServiceManager.AppManager = this; }

    private void Start() 
    {
        PlayerManager.Initialize();
        RoomManager.Initialize();        
    }
}
