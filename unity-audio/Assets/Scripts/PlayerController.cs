using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    public Transform startPosition;
    public float respawnHeight = -10f;
    public float respawnOffset = 2f;
    private bool isFalling = false;
    private bool isJumpingRecently = false;
    private float jumpCooldown = 1.0f;
    private float timeSinceLastJump = 0.0f;
    private Quaternion originalRotation;
    private bool isRespawning = false;

    public AudioClip GrassRun;
    public AudioClip StoneRun;
    [SerializeField]
    private AudioSource runningsoundsSFXAudioSource;
    public AudioClip FlatGrass;
    public AudioClip FlatStone;
    private AudioSource fallingFlatSFX;


    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
        runningsoundsSFXAudioSource = GameObject.Find("RunningSounds").GetComponent<AudioSource>();
        runningsoundsSFXAudioSource.loop = true;
        fallingFlatSFX = GameObject.Find("FallingFlatSounds").GetComponent<AudioSource>();
        

        
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
            if (!runningsoundsSFXAudioSource.isPlaying)
            {
                PlaySound();
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            if (runningsoundsSFXAudioSource.isPlaying)
            {
                runningsoundsSFXAudioSource.Stop();
            }
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
            runningsoundsSFXAudioSource.Stop();
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isJumpingRecently)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);

            isJumpingRecently = true;
            timeSinceLastJump = 0.0f;
        }
        else
        {
            // If not jumping or still within the cooldown, reset the jumping state
            if (timeSinceLastJump < jumpCooldown)
            {
                animator.SetBool("IsJumping", false);
                timeSinceLastJump += Time.deltaTime;
            }
            else
            {
                isJumpingRecently = false;
            }
        }

        // Falling
        if (!IsGrounded() && !isFalling && !isJumpingRecently)
        {
            isFalling = true;
            animator.SetBool("IsFalling", true);
            Debug.Log("Falling");
        }
        else if ((IsGrounded() || isJumpingRecently) && isFalling)
        {
            isFalling = false;
            animator.SetBool("IsFalling", false);
            Debug.Log("Landed");
        }
        // Respawn
        if (transform.position.y < respawnHeight /*&& !isRespawning*/)
        {
            //isRespawning = true;
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            transform.position = startPosition.position + Vector3.up * respawnOffset;
            rb.useGravity = true;
            // Reset the rotation to the original upright orientation
            transform.rotation = originalRotation;
            // Reset animator parameters
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            animator.SetBool("FallingFlat", true);
            Splat();
            FlatSounds();
            ///animator.SetBool("GettingUp", true);
            ///animator.SetBool("BackToIdle", true);

        }

        bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, .15f, ground);
        }
        
    }

    private void Splat()
    {
            animator.SetBool("GettingUp", true);
            animator.SetBool("BackToIdle", true);
    }

    private void PlaySound()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, ground))
        {
            Debug.Log(hit.collider.gameObject.name + "!");
            string material = hit.collider.gameObject.tag;

            if (material != null)
            {
                Debug.Log("Player is standing on material: " + material);
            }

            if (hit.collider.gameObject.CompareTag("Rock"))
            {
                Debug.Log("Stoned");
                runningsoundsSFXAudioSource.clip = StoneRun;
                runningsoundsSFXAudioSource.Play();
            }
            else
            {
                Debug.Log("Grass");
                runningsoundsSFXAudioSource.clip = GrassRun;
                runningsoundsSFXAudioSource.Play();
            }
        
        }
    }
    private void FlatSounds()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, ground))
        {
            string material = hit.collider.gameObject.tag;

            if (material != null)
            {
                Debug.Log("Player is splatted all over: " + material);
            }

            if (hit.collider.gameObject.CompareTag("Rock"))
            {
                fallingFlatSFX.clip = FlatStone;
                fallingFlatSFX.Play();
            }
            else
            {
                fallingFlatSFX.clip = FlatGrass;
                fallingFlatSFX.Play();
            }
        }
    }
}