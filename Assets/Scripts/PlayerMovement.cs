using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    private float moveSpeed = 5f;

    void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Flip Sprite
        if (moveX != 0f){
            spriteRenderer.flipX = moveX < 0f;
        }
    }
}
