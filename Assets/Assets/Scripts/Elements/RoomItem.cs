using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _roomName = null;
    [SerializeField] private TextMeshProUGUI _playerCount = null;
    [SerializeField] private TextMeshProUGUI _hostName = null;



    public void Initialize(string roomName, int playerCount, string hostName)
    {
        gameObject.SetActive(true);
        _roomName.SetText(roomName);
        _playerCount.SetText(playerCount.ToString());
        _hostName.SetText(hostName);
    
    }
   
}
