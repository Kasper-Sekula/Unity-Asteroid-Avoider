using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenSpawn = 1f;
    [SerializeField] private Vector2 forceRange;


    private Camera mainCamera;
    private float timer;

    private void Start() {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0) 
        {
            SpawnAsteroid();

            timer += secondsBetweenSpawn;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector3 direction = Vector2.zero;

        switch(side)
        {
            case 0:
            // LEFT
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f,Random.Range(-1f,1f));
                break;
            case 1:
            // RIGHT
                spawnPoint.x = 1f;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f,Random.Range(-1f,1f));
                break;
            case 2:
            // BOTTOM
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f,1f), 1f);
                break;
            case 3:
            // TOP
                spawnPoint.x = Random.value;
                spawnPoint.y = 1f;
                direction = new Vector2(Random.Range(-1f,1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        GameObject asteroidInstance = Instantiate(
            selectedAsteroid,
            worldSpawnPoint,
            Quaternion.Euler(0f, 0f, Random.Range(0, 360)));

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
