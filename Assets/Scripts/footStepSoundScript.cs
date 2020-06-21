using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStepSoundScript : MonoBehaviour
{

    public AudioClip[] soundsToPlay;
    public AudioSource aud;

    public void playThaSound()
    {
        aud.PlayOneShot(soundsToPlay[Random.Range(0, soundsToPlay.Length)]);
    }
}
