using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTank : SFXUser
{
    private float moveForce = 5f;
    private Vector2 movementY;
    private bool weaponCooldown = false;
    private bool weaponFiring = false;
    [SerializeField]
    public InputActionReference move;
    [SerializeField]
    public InputActionReference fire;
    

    [SerializeField]
    private Rigidbody2D tankBody;
    [SerializeField]
    private Rigidbody2D explosionBody;
    [SerializeField]
    private GameObject barrelExplosion;
    [SerializeField]
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        barrelExplosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();
        WeaponFire();
    }
    void Movement()
    {
        movementY = move.action.ReadValue<Vector2>();
        tankBody.velocity = new Vector2(0f, moveForce * movementY.y);
        explosionBody.transform.position = new Vector2(tankBody.transform.position.x+.7f, tankBody.transform.position.y+.3f);
        
    }

    public void FireWeaponInput(InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
            weaponFiring = true;
        else if (context.canceled)
            weaponFiring = false;

    }

    public void WeaponFire() 
    {
        if (weaponFiring && !weaponCooldown)
        {
            weaponCooldown = true;
            audioManager.ShootSound();
            Vector2 bulletPos = new Vector2(tankBody.position.x + 0.8f, tankBody.position.y + 0.3f);
            Instantiate(bullet, bulletPos, transform.rotation);
            barrelExplosion.SetActive(true);
            StartCoroutine(BarrelExplosionWaitTime());
            StartCoroutine(FiringCooldown());

        }
    }

    IEnumerator FiringCooldown()
    {
        yield return new WaitForSeconds(1.2f);
        weaponCooldown = false;
    }

    IEnumerator BarrelExplosionWaitTime()
    {
        yield return new WaitForSeconds(0.2f);
        barrelExplosion.SetActive(false);


    }


}
