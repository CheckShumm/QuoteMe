using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class AutoScale : MonoBehaviour
{
    [SerializeField] private CanvasScaler _scaler;
    private void Reset() 
    {
        _scaler = gameObject.GetComponent<CanvasScaler>();
    }

    private void Start()
    {
        SetScalerDirection();
    }

#if UNITY_EDITOR
    // Update is called once per frame
    private void Update()
    {
        SetScalerDirection();
    }
#endif

    void SetScalerDirection()
    {   
        float widthRatio = _scaler.referenceResolution.x / Screen.width;
        float heightRatio = _scaler.referenceResolution.y / Screen.height;
        _scaler.matchWidthOrHeight = widthRatio > heightRatio ? 0 : 1;
    }
}
