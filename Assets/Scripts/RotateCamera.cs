using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Rotate the camera using horizontal input
        transform.Rotate(Vector2.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
