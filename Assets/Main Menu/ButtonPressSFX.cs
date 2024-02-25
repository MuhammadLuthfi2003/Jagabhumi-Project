using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSFX : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    void Start()
    {
           
    }

    public void PlayAudio()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(audioClip);
        audioSource.PlayOneShot(audioClip);
        
        
    }
}
