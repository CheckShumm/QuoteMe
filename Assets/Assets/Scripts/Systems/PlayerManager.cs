using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public PlayerProfile LocalPlayerProfile => _localPlayer;
    
    private PlayerProfile _localPlayer;

    public static void Initialize() 
    {
        ServiceManager.PlayerManager = new PlayerManager();
        ServiceManager.PlayerManager._localPlayer = new PlayerProfile();
    }
}
