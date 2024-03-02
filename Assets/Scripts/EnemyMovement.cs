using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null){
            direction = (player.position - transform.position).normalized;
        }
    }

    void Update()
    {
        MoveTowardPlayer();
    }

    void MoveTowardPlayer(){
        if (player != null){
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}