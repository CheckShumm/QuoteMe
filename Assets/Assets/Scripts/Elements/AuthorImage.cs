using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorImage : MonoBehaviour
{
    [SerializeField] private Image _overlay = null;

    public void SetOverlayColor(Color color)
    {
        _overlay.color = color;
    }

}
