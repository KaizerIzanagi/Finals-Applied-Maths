using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject yellowUpgrade, greenUpgrade, blueUpgrade, purpleUpgrade, blackUpgrade, whiteUpgrade;
    [Header("First 3 Turrets")]
    public GameObject redTurret;
    public GameObject orangeTurret;
    public GameObject yellowTurret;
    [Header("Second 3 Turrets")]
    public GameObject greenTurret;
    public GameObject blueTurret;
    public GameObject purpleTurret;
    [Header("Final 2 Turrets")]
    public GameObject blackTurret;
    public GameObject whiteTurret;
    [Header("Turret Controller")]
    public GameObject turrets;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UnlockOrange()
    {
        orangeTurret.SetActive(true); 
        yellowUpgrade.SetActive(true);
    }

    public void UnlockYellow()
    {
        yellowTurret.SetActive(true);
        greenUpgrade.SetActive(true);
    }

    public void UnlockGreen()
    {
        greenTurret.SetActive(true);
        blueUpgrade.SetActive(true);
    }

    public void UnlockBlue()
    {
        blueTurret.SetActive(true);
        purpleUpgrade.SetActive(true);
    }

    public void UnlockPurple()
    {
        purpleTurret.SetActive(true);
        blackUpgrade.SetActive(true);
    }

    public void UnlockBlack()
    {
        blackTurret.SetActive(true);
        whiteUpgrade.SetActive(true);
    }

    public void UnlockWhite()
    {
        whiteTurret.SetActive(true);
    }

    public void ImpostorsWon()
    {
        orangeTurret.SetActive(false);
        yellowTurret.SetActive(false);
        greenTurret.SetActive(false);
        blueTurret.SetActive(false);
        purpleTurret.SetActive(false);
        blackTurret.SetActive(false);
        whiteTurret.SetActive(false);
    }
}
