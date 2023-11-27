using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Animation ammoAnim;
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] GameObject ammoPickupHelpUI;

    bool ammoPickupState = false;
    bool ammoCollected = false;
    DeathHandler deathHandler;

    void Start() 
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    void Update() 
    {
        if (deathHandler.GameHasEnded) 
        {
            ammoPickupHelpUI.SetActive(false);
            return;
        }

        if (ammoPickupState && !ammoCollected)
        {
            ammoPickupHelpUI.SetActive(true);
            CollectAmmo();
            // InvokeRepeating("CollectAmmo", 0f, 1f);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            ammoAnim.Play();
            ammoPickupState = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            ammoPickupState = false;
            ammoPickupHelpUI.SetActive(false);
        }
    }

    void CollectAmmo()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            ammoAmount = 0;
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Ammo"))
                {
                    Destroy(child.gameObject);
                }
            }
            ammoCollected = true;
            ammoPickupHelpUI.SetActive(false);
            // CancelInvoke();
        }
    }
}
