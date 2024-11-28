using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public bool isRed, isBlack, isYellow;
    public TowerScript homing;

    private void Start()
    {
        speed = Random.Range(0.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        LookRotation();
    }

    void EnemyMove()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, GameController.Instance.player.position, step);
    }

    void LookRotation()
    {
        Vector3 relativepos = GameController.Instance.player.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isRed)
        {
            if(other.CompareTag("RedBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                homing.EnemyDetection();
            }
        }
        if (isBlack)
        {
            if (other.CompareTag("BlackBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                homing.EnemyDetection();
            }
        }
        if (isYellow)
        {
            if (other.CompareTag("YellowBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                homing.EnemyDetection();
            }
        }
    }
}
