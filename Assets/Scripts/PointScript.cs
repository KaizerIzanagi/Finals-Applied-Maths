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
        ui = GetComponent<UIScript>();
    }

    
    void Update()
    {
        turret = FindAnyObjectByType<UpgradeScript>();
        if (HP <= 0) 
        {
            turret.ImpostorsWon();
            ui.enemySpawner.SetActive(false);
            ui.GameOver.SetActive(true);
            ui.gameOverT.text = "The Impostors Won. You have Survived " + spawner.waveCount.ToString() + " rounds.";
        }
    }
}
