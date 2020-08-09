using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _roomName = null;
    [SerializeField] private TextMeshProUGUI _playerCount = null;
    [SerializeField] private TextMeshProUGUI _hostName = null;
    [SerializeField] private Transform _border = null;

    public void Initialize(string roomName, int playerCount, int maxPlayers, string hostName)
    {
        gameObject.SetActive(true);
        _roomName.SetText(roomName);
        _playerCount.SetText(playerCount.ToString() + "/" + maxPlayers.ToString());
        _hostName.SetText(hostName);
        int rand = Random.Range(0, 3);
        switch(rand) 
        {
            case 0:
                _border.Rotate(180,0,0);
                break;
            case 1:
                _border.Rotate(0,180,0);
                break;
            case 2:
                _border.Rotate(0,0,180);
                break;
            default:
                break;
        }
    }
   
}
