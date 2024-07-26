using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 1.0f; // Speed at which the cloud moves

    void Update()
    {
        // Move the cloud to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Reset the cloud's position when it goes off scre
    }
}