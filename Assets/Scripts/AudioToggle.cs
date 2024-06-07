using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public AudioSource audioSource;
    public void AudioMute()
    {
        if (audioSource.mute == false)
        {
            audioSource.mute = true;
        }
        else audioSource.mute = false;
    }
}
