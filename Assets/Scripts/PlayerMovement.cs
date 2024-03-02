using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
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
