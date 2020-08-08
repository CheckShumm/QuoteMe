using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : BaseManager
{
    protected override void RegisterManager() { ServiceManager.AppManager = this; }

    private void Start() 
    {
        // The start of our game!
    }
}
