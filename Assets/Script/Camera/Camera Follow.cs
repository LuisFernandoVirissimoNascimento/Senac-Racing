using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The car or the object to follow
    public Vector3 offset = new Vector3(0, 5, -10);  // Offset position of the camera relative to the car
    public float positionDamping = 5f;  // Speed for position following
    public float rotationDamping = 3f;  // Speed for rotation following

    private void LateUpdate()
    {
        if (!target) return;

        // Calculate the desired position based on the target's rotation and offset
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionDamping * Time.deltaTime);

        // Correct the rotation to look at the target while maintaining the correct orientation
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Quaternion desiredRotation = target.rotation * Quaternion.Euler(0, 0, 0); // Flip Y-axis to face forward
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
        }
        else
        {
            Quaternion desiredRotation = target.rotation * Quaternion.Euler(0, 180, 0); // Flip Y-axis to face forward
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
        }
    }
}
