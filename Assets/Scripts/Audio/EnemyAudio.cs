using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource slimeAudio;
    private bool isAlive = true;

    void Start()
    {
        if (slimeAudio != null)
        {
            slimeAudio.loop = true;  
            slimeAudio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive && slimeAudio.isPlaying)
        {
            slimeAudio.Stop();  
        }
    }

    public void Die()
    {
        isAlive = false;
    }
}
