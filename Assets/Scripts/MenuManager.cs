using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioManager audioManager;

    public void StartGame() 
    {
        audioManager = FindObjectOfType<AudioManager>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        audioManager.PlayMainGameSFX();
    }
}
