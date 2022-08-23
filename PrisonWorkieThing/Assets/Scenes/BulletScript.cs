using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Rigidbody _rb;

    public float _speed;



    // Start is called before the first frame update
    void Start()
    {
        _rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myForward = transform.TransformDirection(Vector3.forward);
        _rb.AddForce(myForward * _speed);
    }
}
