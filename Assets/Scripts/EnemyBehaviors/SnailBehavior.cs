using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailBehavior : Enemy
{
    [SerializeField]
    private Rigidbody2D snailBody;

    // Start is called before the first frame update
    protected override void Start()
    {
        scoreReward = 100;
        health = 3f;
        moveForce = -2f;
        body = snailBody;
    }

}
