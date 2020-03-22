using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float forwardMoveSpeed = 8.0f;
    private float backwardMoveSpeed = 3.0f;
    private float turnSpeed = 150.0f;

    private Vector3 movement = Vector3.zero;
    private CharacterController characterController;
    private Animator animator;

    public Animator anim;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        
        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);


        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed;
            
            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
    }
}
