using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{

    public Transform target; // player

    public Vector3 offset = new Vector3(0, 3, -5);

    public float smoothSpeed = 10f;



    void LateUpdate()

    {

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);



        // always look at player

        transform.LookAt(target.position + Vector3.up * 1.5f); // adjust height if needed

    }

}

