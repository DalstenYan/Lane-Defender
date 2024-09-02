using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : SFXUser
{
    protected float health;
    protected float moveForce;
    protected float scoreReward;

    [SerializeField]
    protected Rigidbody2D body;
    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected float DeathAnimationWaitTime = 0.2f;
    [SerializeField]
    public GameObject explosion;


    // Start is called before the first frame update
    protected abstract void Start();

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Lives", (int)health);
        Move();
    }

    protected void Move() 
    {
        body.velocity = new Vector2(moveForce, 0f);
    
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        float waitTime = DeathAnimationWaitTime;
        string tag = collision.gameObject.tag;

        if (tag == "Bullet")
        {
            bool isDead = true;
            health--;
            Destroy(collision.gameObject);

            if (health > 0f)
            {
                waitTime *= 2;
                animator.SetBool("HitStunned", true);
                isDead = false;

            }
            else
                gm.AddScore(scoreReward);

            audioManager.HitSound(isDead);
            GameObject expl = Instantiate(explosion, collision.contacts[0].point, transform.rotation);
            StartCoroutine(ImpactExplosionAnimationWaitTime(expl));
            StartCoroutine(HitStunAnimationWaitTime(waitTime, isDead, moveForce));
            moveForce = 0f;


        }
        else if (tag == "Player" || tag == "Barrier")
        {
            gm.SubtractLives();
            audioManager.LostLife();
            Destroy(gameObject);

        }
        
    }

    IEnumerator ImpactExplosionAnimationWaitTime(GameObject g)
    {
        yield return new WaitForSeconds(.19f);
        Destroy(g);
    }

    IEnumerator HitStunAnimationWaitTime(float sec, bool isDead, float speed) 
    {
        
        yield return new WaitForSeconds(sec);
        if (isDead)
        {
            Destroy(gameObject);
        }
        else 
        {
            animator.SetBool("HitStunned", false);
            moveForce = speed;
        }

    }




}
