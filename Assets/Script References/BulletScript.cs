using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;



public class BulletScript : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject redBulletPrefab, blackBulletPrefab, yellowBulletPrefab;
    public float bulletSpeed, bulletFireRate, baseFireRate;
    public ColorBullet colors;
    public TowerScript towerColor;

    void Start()
    {
        baseFireRate = bulletFireRate;
    }

    void Update()
    {
        bulletFireRate -= Time.deltaTime;
        if (bulletFireRate <= 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (towerColor.colors == ColorBullet.red)
        {
            GameObject rbullet = Instantiate(redBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rigidBullet = rbullet.GetComponent<Rigidbody>();
            rigidBullet.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(rbullet.gameObject, 3f);
        }
        if (towerColor.colors == ColorBullet.black)
        {
            GameObject bbullet = Instantiate(blackBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rigidBullet = bbullet.GetComponent<Rigidbody>();
            rigidBullet.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(bbullet.gameObject, 3f);
        }
        if (towerColor.colors == ColorBullet.yellow)
        {
            GameObject ybullet = Instantiate(yellowBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Rigidbody rigidBullet = ybullet.GetComponent<Rigidbody>();
            rigidBullet.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(ybullet.gameObject, 3f);
        }

        bulletFireRate = baseFireRate;



    }
}
