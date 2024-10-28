using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAudio : MonoBehaviour
{
    [SerializeField] private AudioClip swordSwingSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swordSwingSound;
        audioSource.playOnAwake = false; 
    }

    
    public void PlaySwordSwingSound()
    {
        if (audioSource != null && swordSwingSound != null)
        {
            audioSource.Play();
        }
    }
}

