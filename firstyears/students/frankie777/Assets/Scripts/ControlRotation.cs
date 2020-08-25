using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlRotation : MonoBehaviour
{
    [Tooltip("How many degrees does this does this object rotate per second?")]
    public float rotationSpeed = 180;

    [Header("Keyboard Input")]
    public KeyCode clockwiseKey = KeyCode.Period;
    public KeyCode antiClockwiseKey = KeyCode.Comma;

    private void Update()
    {
        // Time.deltaTime tells us how many seconds passed since we last
        // updated rotation - we multiply by rotationSpeed to work out how
        // many degrees of rotation should happen in that time
        float deltaAngle = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(clockwiseKey))
        {
            transform.Rotate(Vector3.back, deltaAngle);
        }

        if (Input.GetKey(antiClockwiseKey))
        {
            transform.Rotate(Vector3.forward, deltaAngle);
        }
    }
}
