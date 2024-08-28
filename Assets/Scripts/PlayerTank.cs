using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    private float moveForce = 5f;
    private float movementY;

    //GUI
    [SerializeField]
    private float lives = 3f;
    private float score = 0f;
    private float highscore;

    [SerializeField]
    private Rigidbody2D body;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FireWeapon();
    }

    void Movement()
    {
        movementY = Input.GetAxisRaw("Vertical");

        body.velocity = new Vector2(0f, moveForce * movementY);
    }

    void FireWeapon()
    { 
        
    
    }

}
