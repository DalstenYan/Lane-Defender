using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() 
    {
        body.velocity = new Vector2(4.5f, 0f);

    }
}
