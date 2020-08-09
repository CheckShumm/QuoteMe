using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    public void ExtPlayOneShot() 
    {
        ServiceManager.ViewManager.SfxAudioSource.PlayOneShot(_clip, 1.0f);
    }
}
