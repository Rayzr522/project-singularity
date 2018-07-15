using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCamera : MonoBehaviour
{

    public Transform target;

    public float moveSpeed = 1.5f;

    public float rotationSpeed = 1.2f;

    void Update()
    {
        Follow();
        Rotate();
    }

    void Follow()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        // keep Z position since it's 2D
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

    void Rotate()
    {
        // We're using the 'right' property because an angle of 0 is all the way to the right, an angle of 90 is straight up, etc.
        float angle = Mathf.Atan2(GameManager.instance.right.y, GameManager.instance.right.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
