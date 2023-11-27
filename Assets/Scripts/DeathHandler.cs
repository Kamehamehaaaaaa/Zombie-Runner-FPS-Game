using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    bool gameHasEnded = false;
    public bool GameHasEnded { get { return gameHasEnded; } }

    void Start() 
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        gameHasEnded = true;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        DisableCursorMovement();
    }

    void DisableCursorMovement()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<FirstPersonController>().enabled = false;
        FindObjectOfType<StarterAssetsInputs>().cursorLocked = false;
        FindObjectOfType<StarterAssetsInputs>().cursorInputForLook = false;
    }
}
