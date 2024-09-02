using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : Enemy
{
    [SerializeField]
    private Rigidbody2D slimeBody;

    // Start is called before the first frame update
    protected override void Start()
    {
        scoreReward = 150;
        health = 5f;
        moveForce = -1f;
        body = slimeBody;
        
    }
}
