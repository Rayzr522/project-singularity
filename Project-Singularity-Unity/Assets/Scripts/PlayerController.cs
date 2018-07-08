using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movement variables
    public float moveSpeed = 3.0f;
    public float jumpVelocity = 10.0f;

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
        rb = GetComponent<Rigidbody2D>();
        floorCheck = GetComponent<EdgeCollider2D>();
        anim = GetComponent<Animator>();
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
        velocity.x = move * moveSpeed;

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
            Vector3 localScale = transform.localScale;
            localScale.x = move < 0 ? -1 : 1;
            transform.localScale = localScale;
        }

        // Shoot your gun
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(shotObject, shotOrigin.position, shotOrigin.rotation);
            shot.GetComponent<Shot>().direction = transform.localScale.x;
        }

        // Walking animation
        anim.SetFloat("Speed", Mathf.Abs(move));
        Debug.Log(Mathf.Abs(move));
    }
}
