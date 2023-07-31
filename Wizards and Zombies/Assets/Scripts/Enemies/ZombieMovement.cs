using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    [SerializeField] float speed;

    Vector2 movementDir;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDir = player.transform.position - transform.position;
        movementDir = movementDir.normalized;
        movementDir *= speed;

        rb2D.velocity = movementDir;
    }
}
