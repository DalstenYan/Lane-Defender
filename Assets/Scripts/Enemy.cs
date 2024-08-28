using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float health;
    protected float moveForce;
    protected Rigidbody2D body;

    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(health);
    }

    protected void Move() 
    {
        body.velocity = new Vector2(moveForce, 0f);
    
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {

        //TODO

        if (collision.gameObject == null) 
        { }
        Debug.Log(collision.gameObject);
        
    }

}
