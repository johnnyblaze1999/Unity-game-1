using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
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

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
