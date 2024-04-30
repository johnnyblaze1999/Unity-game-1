using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Stop if scored 20 or more point
        if (CurrentScore.score >= 20 && CurrentScore.score <= 40 || (CurrentScore.score > 50 && CurrentScore.score < 70)){
            //CancelInvoke("SpawnEnemy");
            return;
        }
        // Shorter spawn interval
        if (CurrentScore.score > 40 && CurrentScore.score <= 50){
            spawnInterval = 2.5f;
        }
        if (CurrentScore.score > 70){
            spawnInterval = 1.5f;
        }

        // Choose a random side (0: right, 1: bottom, 2: left, 3: top)
        int side = Random.Range(0, 4);

        // Calculate spawn position just outside of the camera view based on the chosen side
        Vector3 spawnPosition = Vector3.zero;

        switch (side)
        {
            case 0: // Right
                spawnPosition = new Vector3(mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect, Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize), 0);
                break;

            case 1: // Bottom
                spawnPosition = new Vector3(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect, mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect), mainCamera.transform.position.y - mainCamera.orthographicSize, 0);
                break;

            case 2: // Left
                spawnPosition = new Vector3(mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect, Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize), 0);
                break;

            case 3: // Top
                spawnPosition = new Vector3(Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect, mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect), mainCamera.transform.position.y + mainCamera.orthographicSize, 0);
                break;
        }

        // Instantiate the enemy at the spawn position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Destroy the enemy when it reaches the other side of the screen
        Destroy(enemy, (2 * mainCamera.orthographicSize * mainCamera.aspect + 2) / enemy.GetComponent<EnemyMovement>().moveSpeed);
    }
}