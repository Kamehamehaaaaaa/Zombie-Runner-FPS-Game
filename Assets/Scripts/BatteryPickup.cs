using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;
    [SerializeField] GameObject batteryPickupHelpUI;

    bool batteryPickupState = false;
    bool batteryCollected = false;
    FlashLightSystem flashLightSystem;
    DeathHandler deathHandler;

    void Start() 
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    void Update() 
    {
        if (deathHandler.GameHasEnded)
        {
            batteryPickupHelpUI.SetActive(false);
            return;
        }

        if (batteryPickupState && !batteryCollected)
        {
            batteryPickupHelpUI.SetActive(true);
            InvokeRepeating("CollectBattery", 0f, 1f);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            flashLightSystem = other.GetComponentInChildren<FlashLightSystem>();
            batteryPickupState = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            batteryPickupState = false;
            batteryPickupHelpUI.SetActive(false);
        }
    }

    void CollectBattery()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flashLightSystem.RestoreLightAngle(restoreAngle);
            flashLightSystem.AddLightIntensity(addIntensity);
            restoreAngle = 0f;
            addIntensity = 0f;
            Destroy(gameObject);
            batteryCollected = true;
            batteryPickupHelpUI.SetActive(false);
        }
    }
}
