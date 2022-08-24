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
    bool canShoot = true;
    public float shootCoolDown = 1f;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //instantiate a bullet and make it a variable so we can alter it
        if (canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
            coolDownStart();
        }
    }

    public void coolDownStart()
    {
        StartCoroutine(coolDownCorutine());
    }

    IEnumerator coolDownCorutine()
    {
        float timer = shootCoolDown;

        canShoot = false;

        while (timer > 0)
        {
            timer--;

            yield return new WaitForSeconds(1f);
        }

        canShoot = true;
    }
}
