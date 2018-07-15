using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screecher : MonoBehaviour, Enemy
{
    public float followSpeed = 0.6f;
    public float returnSpeed = 1.5f;

    public float maxFollowDistance = 5f;

    public float startingHealth = 10f;

    private Vector3 origin;

    private float health;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        origin = transform.position;
        health = startingHealth;
    }

    /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
    {
        FollowPlayer();
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        GUITools.Healthbar(health / startingHealth, transform.position);
    }

    void FollowPlayer()
    {
        Vector3 target = GameManager.instance.player.transform.position;
        Vector3 position = transform.position;
        float speed = followSpeed;

        if ((target - position).magnitude > maxFollowDistance)
        {
            speed = returnSpeed;
            target = origin;
        }

        Vector3 distance = target - position;
        Vector3 direction = distance.normalized;

        Vector3 movement = direction * speed * Time.deltaTime;

        if (movement.magnitude > distance.magnitude)
        {
            position = target;
        }
        else
        {
            position += movement;
        }

        transform.position = position;
    }


    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Kill();
        }
    }

    public float GetHealth()
    {
        return health;
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
