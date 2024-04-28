using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector3 direction;
    private float damage = 1;

    // Zigzag movement variables
    private float frequency = 5.0f;
    private float amplitude = 2.0f;
    private Vector3 pos;
    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        if (player != null){
            direction = (player.position - pos).normalized;
        }
        
        // Control zigzag movement
        if (direction.x > 0.9 || direction.x < -0.9){
            axis = transform.up;
        } else {
            axis = transform.right;
        }
        
    }

    void Update()
    {
        MoveTowardPlayer();
    }

    void MoveTowardPlayer()
    {
        if (player != null){
            pos += direction * moveSpeed * Time.deltaTime;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * amplitude;
        }
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false; // moving right
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true; // moving left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
