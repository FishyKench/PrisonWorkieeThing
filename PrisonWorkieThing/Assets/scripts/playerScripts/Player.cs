using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Variables")]

    [SerializeField] public float movementSpeed = 5f;


    [Header("References")]
    public Rigidbody rb;
    public Vector3 movement;



    [Header("Stats")]
    public float _health = 3;

    void Update()
    {
        movePlayer();
    }

    //private void FixedUpdate()
    //{
    //    //This wasn't being used but i didn't remove it just to be sure not to ruin anything lol

    //    //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    //}


    void movePlayer()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");

        Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
    }

    public void Damage()
    {
        _health -= 1;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
