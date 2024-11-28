using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SusColor
{
    red,
    black,
    yellow
}
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject enemy;
    public float interval, baseInterval;
    public GameObject redSus, blackSus, yellowSus;
    public SusColor suspColor;
    public TowerScript towerBullet;

    void Start()
    {
        baseInterval = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;

        if (interval <= 0)
            {
                Spawn();
            }
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);

        interval = baseInterval;
    }
}
