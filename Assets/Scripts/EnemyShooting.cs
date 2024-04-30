using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    //public Transform bulletPos;
    private GameObject player;
    private Rigidbody2D rb;
    private float speed = 3f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Control direction
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = direction.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Shoot every second
        if(timer > 1){
            timer = 0;
            shoot();
        }

        // Flip the sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (player.transform.position.x > transform.position.x){
            spriteRenderer.flipX = false;
        }
        else if (player.transform.position.x < transform.position.x){
            spriteRenderer.flipX = true;
        }
    }

    void shoot(){
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Health playerHealth = other.GetComponent<Health>();
            playerHealth.TakeDamage(1);
        }
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
