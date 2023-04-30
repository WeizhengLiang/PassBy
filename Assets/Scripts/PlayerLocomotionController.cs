using System.Collections;
using System.Collections.Generic;
using Polyperfect.Common;
using Polyperfect.People;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerLocomotionController : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovementInputController _movement;
    private People_WanderScript followTargetInfo;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject restartUI;
    [SerializeField] private GameObject settingUI;
    

    private Vector2 smoothDeltaPosition = Vector2.zero;
    public Vector2 velocity = Vector2.zero;
    public float magnitude = 0.25f;
    public GameObject followTarget;

    private void OnEnable()
    {
        _movement = GetComponent<PlayerMovementInputController>();
        _animator = GetComponent<Animator>();
        followTargetInfo = followTarget.GetComponent<People_WanderScript>();
        reset();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        
    }
    public bool shouldMove;
    public bool shouldTurn;
    public float turn;

    public GameObject look;

    public GameObject arrow;

    public Transform arrowBone;
    public GameObject arrowPrefab;

    

    public void Update()
    {
        Vector3 worldDeltaPosition = _movement.nextPosition - transform.position;

        //Map to local space
        float dX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dX, dY);

        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        if (Time.deltaTime > 1e-5f)
        {
            velocity = smoothDeltaPosition / Time.deltaTime;
        }

        shouldMove = velocity.magnitude > magnitude;

        // bool isAiming = (_movement.aimValue == 1f);
        //
        // if (isAiming)
        // {
        //     if ((_movement.fireValue == 1f))
        //     {
        //         _animator.SetTrigger("Fire");
        //         arrow.SetActive(false);
        //         //StartCoroutine(FireArrow());
        //     }
        //
        //
        //     if (_animator.GetCurrentAnimatorStateInfo(2).IsName("Fire"))
        //     {
        //         arrow.SetActive(false);
        //     }
        //     else
        //     {
        //         arrow.SetActive(true);
        //     }
        //
        //  
        //
        //     
        //     _movement.fireValue = 0f;
        // }
        //_animator.SetBool("IsAiming", isAiming);
        if (Input.GetKey(KeyCode.LeftShift) && shouldMove)
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isRunning", shouldMove);
            _movement.speed = 5f;
        }
        else if (shouldMove)
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isWalking", shouldMove);
            _movement.speed = 3f;
        }
        else
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isWalking", false);
        }

        if (followTargetInfo.CurrentState == Common_WanderScript.WanderState.Dead)
        {
            reset();
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingUI.activeSelf == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
            
            
        }
        
        //Saves a screenshot when a button is pressed


        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenCapture.CaptureScreenshot("screenshot.png");
            Debug.Log("A screenshot was taken!");
        }
        
        
        
        // _animator.SetFloat("VelocityX", velocity.x);
        // _animator.SetFloat("VelocityY", Mathf.Abs(velocity.y));

    }

    private void OnAnimatorMove()
    {
        //Update the position based on the next position;
        transform.position = _movement.nextPosition;
    }

    [SerializeField]
    private Transform fireTransform;

    IEnumerator FireArrow()
    {
        GameObject projectile = Instantiate(arrowPrefab);
        projectile.transform.forward = look.transform.forward;
        projectile.transform.position = fireTransform.position + fireTransform.forward;
        //Wait for the position to update
        yield return new WaitForSeconds(0.1f);

        //projectile.GetComponent<ArrowProjectile>().Fire();
        
    }

    private void reset()
    {
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isWalking", false);
        _animator.SetBool("isDead", false);
        
    }

    private void Die()
    {
        _animator.SetBool("isDead", true);
        playerInput.DeactivateInput();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        restartUI.SetActive(true);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        settingUI.SetActive(true);
        playerInput.DeactivateInput();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        settingUI.SetActive(false);
        playerInput.ActivateInput();
        Time.timeScale = 1f;
    }

}
