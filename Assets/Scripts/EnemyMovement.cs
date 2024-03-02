using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector3 direction;
    private float damage = 1;

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

    void MoveTowardPlayer()
    {
        if (player != null){
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("L");
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}