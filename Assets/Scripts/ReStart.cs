using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReStart : MonoBehaviour
{
    // [SerializeField] private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        // playerInput.ActivateInput();
        Time.timeScale = 1f;
    }
}
