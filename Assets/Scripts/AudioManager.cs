using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip menuGameSFX;
    [SerializeField] [Range(0f, 1f)] float menuGameSFXVol = 0.25f;
    [SerializeField] AudioClip mainGameSFX;
    [SerializeField] [Range(0f, 1f)] float mainGameSFXVol = 0.25f;

    AudioSource audioSource;

    void Awake() 
    {
        int numMusicPlayers = FindObjectsOfType<AudioManager>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(menuGameSFX, menuGameSFXVol);
        }
    }

    public void PlayMainGameSFX()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(mainGameSFX, mainGameSFXVol);
    }
}
