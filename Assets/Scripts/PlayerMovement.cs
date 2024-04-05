using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
<<<<<<< Updated upstream
=======
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;
    public Animator animator;
    public Text gameoverText;
>>>>>>> Stashed changes

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        

        if (Input.GetKey(KeyCode.W)){
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S)){
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)){
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)){
            moveX = +1f;
        }
        if (moveX != 0 || moveY != 0){
            animator.SetFloat("Speed", 1f);
        }
        else{
            animator.SetFloat("Speed", 0f);
        }

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Flip Sprite
        if (moveX != 0f){
            spriteRenderer.flipX = moveX < 0f;
        }
    }
}
