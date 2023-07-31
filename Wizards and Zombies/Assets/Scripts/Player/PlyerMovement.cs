using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlyerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector2 movementVector;

    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        movementVector = new Vector2();
    }


    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = -Input.GetAxisRaw("Vertical");
        movementVector = movementVector.normalized;
        movementVector *= speed;

        rb2D.velocity = movementVector;
    }
}
