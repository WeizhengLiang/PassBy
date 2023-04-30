using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Resume : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private GameObject settingUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeFunc()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        settingUI.SetActive(false);
        playerInput.ActivateInput();
        Time.timeScale = 1f;
    }
}
