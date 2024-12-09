using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource fontesSFX;


    public void playSound(AudioClip som)
    {
        fontesSFX.PlayOneShot(som);
    }


}
