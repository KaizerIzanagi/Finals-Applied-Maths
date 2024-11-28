using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float Cash;

    [Header("Scripts")]
    public UpgradeScript turret;
    public EnemyGenerator spawner;
    public UIScript ui;
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        Cash = 0;
        turret = FindObjectOfType<UpgradeScript>();
    }

    
    void Update()
    {
        if (HP <= 0) 
        {
            turret.ImpostorsWon();
            turret.turrets.SetActive(false);
            Cash = 0;
        }
    }
}
