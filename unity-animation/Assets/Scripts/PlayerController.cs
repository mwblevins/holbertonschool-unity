using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    public Transform startPosition;
    public float respawnHeight = -10f;
    public float respawnOffset = 2f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalRotation = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        // Apply rotation based on 'A' and 'D' input
        transform.Rotate(0f, horizontalRotation * rotationSpeed * Time.deltaTime, 0f);
        // Calculate the movement direction based on the current rotation
        Vector3 movementDirection = transform.forward * verticalMovement;
        Vector3 movement = movementDirection * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        // Set up Bool for when character is moving. Idle to Running
        if (movementDirection != Vector3.zero && IsGrounded())
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        //Respawn when falling off edge
        if (transform.position.y < respawnHeight)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            transform.position = startPosition.position + Vector3.up * respawnOffset;
            rb.useGravity = true;
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .2f, ground);
    }
}
