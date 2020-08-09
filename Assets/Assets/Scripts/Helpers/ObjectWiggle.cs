using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWiggle : MonoBehaviour
{
    [SerializeField] private float _wiggleDelta;
    [SerializeField] private float _wiggleTime;

    private void Start() 
    {
        transform.Rotate(0, 0, -_wiggleDelta);
        LeanTween.rotateZ(gameObject, transform.localEulerAngles.z + 2 * _wiggleDelta, _wiggleTime).setLoopPingPong();
    }
}
