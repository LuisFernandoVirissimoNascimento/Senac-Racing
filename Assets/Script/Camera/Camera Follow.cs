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

        // Target position with offset
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, positionDamping * Time.deltaTime);

        // Smoothly rotate the camera to look at the car's forward direction
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
    }
}
