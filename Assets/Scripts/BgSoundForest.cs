using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }


    public void StopMusic()
    {
        audioSource.Stop()  ;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
   
}
