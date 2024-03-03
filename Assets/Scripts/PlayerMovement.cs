using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Camera mainCamera;
    public Text gameoverText;

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

        Vector3 moveDirection = new Vector3(moveX, moveY).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
