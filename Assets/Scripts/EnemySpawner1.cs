using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject frogPrefab;
    [SerializeField]
    private float minSpawn;
    [SerializeField]
    private float maxSpawn;

    private float timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentScore.score < 10){
            return;
        }

        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0){
            Instantiate(frogPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn() {
        timeUntilSpawn = Random.Range(minSpawn, maxSpawn);
    }
}
