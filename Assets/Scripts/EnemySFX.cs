using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    AudioSource audioSource;
    DeathHandler deathHandler;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    void Update() 
    {
        if (deathHandler.GameHasEnded)
        {
            PlayDeathSFX();
        }
    }

    public void PlayAttackSFX()
    {
        if (deathHandler.GameHasEnded) { return; }
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayDeathSFX()
    {
        audioSource.Stop();
    }
}
