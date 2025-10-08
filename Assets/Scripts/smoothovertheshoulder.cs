using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothovertheshoulder : MonoBehaviour
{

    public Transform target;          // player

    public Vector3 offset = new Vector3(0.5f, 1.8f, -2f);

    public float smoothTime = 0.1f;  // smooth damping

    public float mouseSensitivity = 2f;



    private Vector3 velocity = Vector3.zero;

    private float yaw = 0f;



    void LateUpdate()

    {

        // rotate camera around player with mouse X

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        yaw += mouseX;



        Vector3 rotatedOffset = Quaternion.Euler(0f, yaw, 0f) * offset;



        // smooth follow using SmoothDamp

        Vector3 desiredPosition = target.position + rotatedOffset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);



        // always look at the player

        transform.LookAt(target.position + Vector3.up * 1.5f);

    }

}


