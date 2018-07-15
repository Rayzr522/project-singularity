using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    public Transform target;

    public float moveSpeed = 50.0f;

    void Update()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        // keep Z position since it's 2D
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
