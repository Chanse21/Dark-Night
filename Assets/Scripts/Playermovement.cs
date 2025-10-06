using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float movespeed = 5f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void FixedUpdate() // Use FixedUpdate for physics

{
    Vector3 moveDirection = Vector3.zero;

    if (Input.GetKey("d"))
    {
        moveDirection += Vector3.right;
    }

    if (Input.GetKey("a"))
    {
        moveDirection += Vector3.left;
    }

    if (Input.GetKey("w"))
    {
        moveDirection += Vector3.forward;
    }

    if (Input.GetKey("s"))
    {
        moveDirection += Vector3.back;
    }

    // Normalize to prevent faster diagonal movement
    moveDirection.Normalize();
    // Move using physics
    rb.MovePosition(rb.position + moveDirection * movespeed * Time.fixedDeltaTime);
  }
}
