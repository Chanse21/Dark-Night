using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;    // assign your enemy prefab

    public Transform player;          // assign your player

    public float spawnDistance = 5f;  // distance behind the player

    public float spawnHeight = 0f;    // Y position for enemy spawn

    public float spawnInterval = 3f;  // seconds between spawns



    private float timer;



    void Update()

    {

        if (player == null || enemyPrefab == null) return;



        timer += Time.deltaTime;



        if (timer >= spawnInterval)

        {

            SpawnEnemy();

            timer = 0f;

        }

    }



    void SpawnEnemy()

    {

        // spawn position behind the player

        Vector3 spawnPos = player.position - player.forward * spawnDistance;

        spawnPos.y = spawnHeight; // keep on the ground



        // instantiate enemy

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);



        // assign player target to enemy (if using follow script)

        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)

        {

            enemyScript.player = player.gameObject;

        }

    }

}


