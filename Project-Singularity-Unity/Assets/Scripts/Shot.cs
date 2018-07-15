using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public float speed = 5f;
    public float destroyDelay = 3f;

    public float damageAmount = 4f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position += transform.right * speed * Time.deltaTime;
        transform.position = position;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            // Make shot go poof :p
            Destroy(gameObject);
        }
    }

}
