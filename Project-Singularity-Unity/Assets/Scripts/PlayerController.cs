using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movement variables
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 8.0f;
    public float jumpVelocity = 10.0f;
    public float fallSpeedMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Movement components
    public ParticleSystem sprintingParticles;

    // Shooting logic
    public Transform shotOrigin;
    public GameObject shotObject;

    // Components
    private Rigidbody2D rb;
    private EdgeCollider2D floorCheck;
    private Animator anim;

    public bool onGround
    {
        get
        {
            return floorCheck.IsTouchingLayers();
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameManager.instance.player = this;

        rb = GetComponent<Rigidbody2D>();
        floorCheck = GetComponent<EdgeCollider2D>();
        anim = GetComponent<Animator>();

        sprintingParticles.Stop();
    }

    void Update()
    {
        // Quick reset code
        if (transform.position.y < -50)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector2.zero;
        }

        // Get velocity
        Vector2 velocity = rb.velocity;

        // Horizontal movement
        float move = Input.GetAxis("Horizontal");
        bool sprinting = Input.GetButton("Sprint");

        if (GameManager.instance.right.x != 0)
        {
            velocity.x = GameManager.instance.right.x * move * (sprinting ? sprintSpeed : walkSpeed);
        }
        else
        {
            velocity.y = GameManager.instance.right.y * move * (sprinting ? sprintSpeed : walkSpeed);
        }


        if (velocity.y < 0)
        {
            velocity += Vector2.up * Physics2D.gravity.y * (fallSpeedMultiplier - 1) * Time.deltaTime;
        }
        else if (velocity.y > 0 && !Input.GetButton("Jump"))
        {
            velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Sprinting
        if (sprintingParticles.isPlaying != sprinting)
        {
            if (sprinting)
            {
                sprintingParticles.Play();
            }
            else
            {
                sprintingParticles.Stop();
            }
        }


        // Jumping code
        if (Input.GetButtonDown("Jump") && onGround)
        {
            velocity.y = jumpVelocity;
        }

        // Set velocity
        rb.velocity = velocity;

        // Change sprite direciton based on move direction
        if (Mathf.Abs(move) > 0.05)
        {
            bool left = move < 0;

            Vector3 localScale = transform.localScale;
            localScale.x = left ? -1 : 1;
            transform.localScale = localScale;


            ParticleSystem.MainModule main = sprintingParticles.main;
            main.startRotationYMultiplier = left ? Mathf.PI : 0f;
        }

        // Shoot your gun
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(shotObject, shotOrigin.position, shotOrigin.rotation);
            shot.GetComponent<Shot>().direction = transform.localScale.x;
        }

        // Walking animation
        anim.SetFloat("Speed", Mathf.Abs(move));
    }
}
