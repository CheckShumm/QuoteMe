using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDisplayWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerName = null;
    [SerializeField] private Transform _border = null;

    public void Initialize(string playerName)
    {
        gameObject.SetActive(true);
        _playerName.SetText(playerName);
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
