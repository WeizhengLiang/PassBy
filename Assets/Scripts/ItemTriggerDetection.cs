using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ItemTriggerDetection : MonoBehaviour
{
    public LayerMask detectionLayer; // The layer to detect collisions with
    public LayerMask EndPointLayer;
    public CatleUI cas;
    public PlayerInput playerInput;
    [SerializeField] private GameObject EndGameUI;

    private void OnTriggerEnter(Collider other)
    {
        if (detectionLayer == (detectionLayer | (1 << other.gameObject.layer)))
        {
            cas.isHealing = true;
            // Do something when a collider enters the trigger, such as play a sound or increase a score
            Debug.Log("Collider entered trigger.");
            gameObject.SetActive(false);
            
        }

        if (EndPointLayer == (EndPointLayer | (1 << other.gameObject.layer)))
        {
            EndGameUI.SetActive(true);
            Animator ani = GameObject.FindWithTag("Player").GetComponent<Animator>();
            
            
            ani.SetBool("isRunning", false);
            ani.SetBool("isWalking", false);
            ani.SetBool("isWaving", true);
            playerInput.DeactivateInput();
            Time.timeScale = 0f;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (detectionLayer == (detectionLayer | (1 << other.gameObject.layer)))
        {
            // Do something when a collider exits the trigger, such as stop a sound or decrease a score
            Debug.Log("Collider exited trigger.");
        }
    }
}
