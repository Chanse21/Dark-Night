using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3f;

    public GameObject player;



    void Update()

    {

        if (player == null) return;



        // move toward player

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);



        // rotate to face player

        Vector3 direction = player.transform.position - transform.position;

        direction.y = 0; // keep upright

        if (direction.magnitude > 0.1f)

            transform.rotation = Quaternion.LookRotation(direction);

    }



    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Light"))

        {

            Destroy(gameObject);

        }

    }

}

