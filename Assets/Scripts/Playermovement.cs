using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float rotationSpeed = 10f;

    public Transform cameraTransform; // assign your camera here

    public Transform lightTransform;  // assign your light here



    private Rigidbody rb;



    void Start()

    {

        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true; // prevent tipping over

    }



    void FixedUpdate()

    {

        // get input

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");



        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;



        if (inputDir.magnitude >= 0.1f)

        {

            // get camera-relative movement direction

            Vector3 camForward = cameraTransform.forward;

            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;

            camRight.y = 0f;

            camForward.Normalize();

            camRight.Normalize();



            Vector3 moveDir = camForward * inputDir.z + camRight * inputDir.x;



            // rotate player toward move direction

            Quaternion targetRotation = Quaternion.LookRotation(moveDir);

            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));



            // move player

            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);



            // rotate light to match movement direction

            if (lightTransform != null)

            {

                Quaternion lightRotation = Quaternion.LookRotation(moveDir);

                lightTransform.rotation = lightRotation;

            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}

