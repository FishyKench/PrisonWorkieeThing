using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        follow();
    }

    private void follow()
    {
        //transform.position = new Vector3(target.transform.position.x, offset.y, target.transform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
    }
}
