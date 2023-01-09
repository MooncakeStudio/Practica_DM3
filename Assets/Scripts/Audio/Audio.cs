using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource src;

    public void PlaySound(AudioClip clip)
    {
        src.PlayOneShot(clip);
    }

    public void PlaySoundCambioEscena(AudioClip clip)
    {
        //GameManager.instance.playSound(clip);
        StartCoroutine(GameManager.instance.playOnce(clip));
    }
}
