using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //where to shoot from
    public Transform firePoint;
    //bullet prefab
    public GameObject bulletPrefab;
    //bullet speed
    public float bulletForce = 20f;
    // shooting cool down
    bool canShoot;
    public float shootCoolDown = 1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            coolDownStart();
            Shoot();
        }
    }

    void Shoot()
    {
        //instantiate a bullet and make it a variable so we can alter it
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

    public void coolDownStart()
    {
        StartCoroutine(coolDownCorutine());
    }

     IEnumerator coolDownCorutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        canShoot = true;
    }
}
