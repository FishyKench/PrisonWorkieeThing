using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Variables")]

    public float movementSpeed = 5f;
    private Vector3 moveDir;

    [Header("Dashing")]

    //dash
    public float dashSpeed = 10f;
    public float maxDashes = 1f;
    public float dashAmount;

    private float dashLength = .3f;

    public float dashCooldown = 2f;


    bool isDashing = false;



    [Header("Stats")]

    public float health = 3;


    [Header("References")]

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        dashAmount = maxDashes;
    }

    void Update()
    {
        MovementInput();
    }

    void MovementInput()
    {
        //movement
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        //dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashAmount > 0 && (Mathf.Abs(moveDir.x) > 0 || Mathf.Abs(moveDir.z) > 0))
        {

            if (!isDashing)
            {
                StartCoroutine(dash());
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = moveDir * movementSpeed;
        }
    }

    IEnumerator dash()
    {
        isDashing = true;
        dashAmount -= 1f;
        print("SHAD");
        rb.velocity = moveDir * dashSpeed;

        yield return new WaitForSeconds(dashLength);

        if (dashAmount <= 0)
        {
            StartCoroutine(regenDash());
        }
        isDashing = false;

    }

    IEnumerator regenDash()
    {
        float timer = dashCooldown;

        while (timer > 0)
        {
            timer--;

            yield return new WaitForSeconds(1f);
        }

        dashAmount = maxDashes;
    }

    public void Damage()
    {
        health -= 1;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
