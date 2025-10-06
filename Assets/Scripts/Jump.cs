using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpForce = 7f;      // How high the player jumps

    private Rigidbody rb;

    private bool isGrounded = false;



    void Start()

    {

        rb = GetComponent<Rigidbody>();

    }



    void Update()

    {
        // Jump when Space is pressed and player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void OnCollisionEnter(Collision collision)

    {
        // Detect if the player landed on an object tagged "Ground"

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)

    {
        // Detect when the player leaves the ground

        if (collision.gameObject.CompareTag("Ground"))

        {
            isGrounded = false;
        }
    }

}


