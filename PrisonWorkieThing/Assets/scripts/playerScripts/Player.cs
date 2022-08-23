using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Variables")]

    [SerializeField] public float movementSpeed = 5;


    [Header("References")]
    public Rigidbody rb;
    public Vector3 movement;
    //public GameObject _bullet;
    //public Transform _bullesOffSet;



    [Header("Stats")]
    public float _health = 3;



    void Start()
    {

    }

    void Update()
    {
        movePlayer();
        //shoot();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }


    void movePlayer()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

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


    //public void shoot()
    //{
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Instantiate(_bullet, _bullesOffSet.position, _bullesOffSet.localRotation);
    //    }
    //}
}
