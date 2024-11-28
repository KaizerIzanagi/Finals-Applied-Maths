using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum ColorBullet
{
    red,
    yellow,
    black
}

public class TowerScript : MonoBehaviour
{
    public float moveSpeed, rangeValue, x, y, z, rotSpeed;
    //Acts as Settable Vectors
    public Quaternion rotation, eularAngles, currentRotation;
    public Vector3 currentEulerAngles;
    public ColorBullet colors;
    public BulletScript bulletColor;
    public SpinningCube cube;
    public GameObject[] sus;
    public GameObject TargetA;

    // Update is called once per frame
    void Update()
    {
        EnemyDetection();

        switch (colors)
        {
            case ColorBullet.red:
                cube.redCube.SetActive(true);
                cube.blackCube.SetActive(false);
                cube.yellowCube.SetActive(false);
                break;
            case ColorBullet.black:
                cube.redCube.SetActive(false);
                cube.blackCube.SetActive(true);
                cube.yellowCube.SetActive(false);
                break;
            case ColorBullet.yellow:
                cube.redCube.SetActive(false);
                cube.blackCube.SetActive(false);
                cube.yellowCube.SetActive(true);
                break;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

    public void EnemyDetection()
    {
        sus = GameObject.FindGameObjectsWithTag("Sus");
        TargetA = sus[0];
        float dist = Vector3.Distance(transform.position, TargetA.transform.position);
        if (dist <= rangeValue)
        {
            Debug.Log("Amogus Detected");
            LookRotation();
        }
    }

    void LookRotation()
    {
        Vector3 relativepos = TargetA.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos, Vector3.up);
        transform.rotation = rotation;
    }

    void OnMouseDown()
    {
        if (colors == ColorBullet.red)
        {
            colors = ColorBullet.black;
        }
        else if (colors == ColorBullet.black)
        {
            colors = ColorBullet.yellow;
        }
        else if (colors == ColorBullet.yellow)
        {
            colors = ColorBullet.red;
        }
    }
}
