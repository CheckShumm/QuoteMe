using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class RoomPanel : BasePanel
{
    override protected void OnActivate()
    {
        Debug.Log("Room Panel onActive!");
    }
}
