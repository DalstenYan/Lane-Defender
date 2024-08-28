using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : Enemy
{
    [SerializeField]
    private Rigidbody2D snakeBody;

    // Start is called before the first frame update
    protected override void Start()
    {
        health = 1f;
        moveForce = -4f;
        body = snakeBody;
    }


}
