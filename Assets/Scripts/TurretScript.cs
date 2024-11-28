using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField]
    [Header("Unchangeable Fields")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private Transform target;
    public string impostorTag = "Sus";
    public Transform rotateTurret;
    [SerializeField]
    [Header("Changable Fields")]
    public float rotationSpeed;
    public float bulletSpeed, bulletFireRate, baseFireRate, bulletCountdown;
    public float range;

    void Start()
    {
        baseFireRate = 1;
        InvokeRepeating("Targetting", 0f, 0.5f);
        range = 30;
        rotationSpeed = 10f;
        bulletFireRate = baseFireRate;
        bulletCountdown = 1;
    }

    void Update()
    {
        if (bulletCountdown <= 0)
        {
            Shoot();
            bulletCountdown = bulletFireRate;
        }
        bulletCountdown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        LookRotation();

    }

    void LookRotation()
    {
        Vector3 relativepos = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(-relativepos);
        Vector3 rotation = Quaternion.Lerp(rotateTurret.rotation, lookrotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotateTurret.rotation = Quaternion.Euler (0f, rotation.y, 0f);

    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        PelletScript pelletObject = bulletObject.GetComponent<PelletScript>();

        if (pelletObject != null)
        {
            pelletObject.Attack(target);
        }

    }

    void Targetting()
    {
        GameObject[] impostors = GameObject.FindGameObjectsWithTag("Sus");
        float closestImpostor = Mathf.Infinity;
        GameObject closestTarget = null;

        foreach (GameObject impostor in impostors)
        {
            float impostorDistance = Vector3.Distance(transform.position, impostor.transform.position);
            if (impostorDistance < closestImpostor)
            {
                closestImpostor = impostorDistance;
                closestTarget = impostor;
            }
        }

        if (closestTarget != null && closestImpostor <= range)
        {
            target = closestTarget.transform;
        }
        else
        {
            target = null;
        }

    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    */
}
