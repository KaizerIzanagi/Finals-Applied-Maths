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
    [Header("Text")]
    public TextMeshProUGUI redT, redCostT, redBtnT;
    public TextMeshProUGUI orangeT, orangeCostT, orangeBtnT;
    public TextMeshProUGUI yellowT, yellowCostT, yellowBtnT;
    public TextMeshProUGUI greenT, greenCostT, greenBtnT;
    public TextMeshProUGUI blueT, blueCostT, blueBtnT;
    public TextMeshProUGUI purpleT, purpleCostT, purpleBtnT;
    public TextMeshProUGUI blackT, blackCostT, blackBtnT;
    public TextMeshProUGUI whiteT, whiteCostT, whiteBtnT;
    public TextMeshProUGUI cashT;
    [Header("Costs")]
    public float redCost, orangeCost, yellowCost, greenCost, blueCost, purpleCost, blackCost, whiteCost;
    public float increment;
    [Header("Tower Levels")]
    public float redLevel, orangeLevel, yellowLevel, greenLevel, blueLevel, purpleLevel, blackLevel, whiteLevel;
    public float maxLevel;
    [Header("Buttons")]
    public GameObject redUBtn, orangeUBtn, yellowUBtn, greenUBtn, blueUBtn, purpleUBtn, blackUBtn, whiteUBtn;
    [Header("Misc")]
    public GameObject turrets;
    public PointScript pScript;

    void Start()
    {
        redCost = 500;
        orangeCost = 1000;
        yellowCost = 2500;
        greenCost = 5000;
        blueCost = 7500;
        purpleCost = 10000;
        blackCost = 12500;
        whiteCost = 15000;
        increment = 1.5f;

        redLevel = 1;
        orangeLevel = 0;
        yellowLevel = 0;
        greenLevel = 0;
        blueLevel = 0;
        purpleLevel = 0;
        blackLevel = 0;
        whiteLevel = 0;

        maxLevel = 10;
        pScript = GetComponent<PointScript>();
    }

    public void UpgradeRed()
    {
        if(pScript.Cash >= redCost)
        {
            pScript.Cash -= redCost;
            redCost *= increment;
            redLevel++;
            redT.text = "Upgrade Turret 1 (Current Level: " + redLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            CostTextSetter();
            if (redLevel >= maxLevel)
            {
                redT.text = "Upgrade Turret 1 (Current Level: Max)";
                redUBtn.SetActive(false);
                return;
            }
            return;
        }

    }
    public void UnlockUpgradeOrange()
    {
        
        if (orangeTurret.activeInHierarchy)
        {
            if (pScript.Cash >= orangeCost)
            {
                pScript.Cash -= orangeCost;
                orangeCost *= increment;
                orangeLevel++;
                orangeT.text = "Upgrade Turret 2 (Current Level: " + orangeLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (orangeLevel >= maxLevel)
                {
                    orangeT.text = "Upgrade Turret 1 (Current Level: Max)";
                    orangeUBtn.SetActive(false);
                    return;
                }
                return;
            }
        }

        else if (!orangeTurret.activeInHierarchy)
        {
            pScript.Cash -= orangeCost;
            orangeTurret.SetActive(true);
            yellowUpgrade.SetActive(true);
            orangeCost = 500;
            orangeLevel += 1;
            orangeT.text = "Upgrade Turret 2 (Current Level: " + orangeLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            orangeBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }

    }

    public void UnlockUpgradeYellow()
    {
        if (yellowTurret.activeInHierarchy)
            {
            if (pScript.Cash >= yellowCost)
            {
                pScript.Cash -= yellowCost;
                yellowCost *= increment;
                yellowLevel++;
                yellowT.text = "Upgrade Turret 3 (Current Level: " + yellowLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (yellowLevel >= maxLevel)
                {
                    yellowT.text = "Upgrade Turret 1 (Current Level: Max)";
                    yellowUBtn.SetActive(false);
                }
                return;
            }
        }

        else if (!yellowTurret.activeInHierarchy)
        {
            pScript.Cash -= yellowCost;
            yellowTurret.SetActive(true);
            greenUpgrade.SetActive(true);
            yellowLevel += 1;
            yellowCost = 500;
            yellowT.text = "Upgrade Turret 3 (Current Level: " + yellowLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            yellowBtnT.text = "Upgrade";
            return;
        }

    }

    public void UnlockUpgradeGreen()
    {
        if (greenTurret.activeInHierarchy)
        {
            if (pScript.Cash >= greenCost)
            {
                pScript.Cash -= greenCost;
                greenCost *= increment;
                greenLevel++;
                greenT.text = "Upgrade Turret 4 (Current Level: " + greenLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (greenLevel >= maxLevel)
                {
                    greenT.text = "Upgrade Turret 1 (Current Level: Max)";
                    greenUBtn.SetActive(false);
                }
                return;
            }
        }
        
        else if (!greenTurret.activeInHierarchy)
        {
            pScript.Cash -= greenCost;
            greenTurret.SetActive(true);
            blueUpgrade.SetActive(true);
            greenLevel += 1;
            greenCost = 500;
            greenT.text = "Upgrade Turret 4 (Current Level: " + greenLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            greenBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }

    }

    public void UnlockUpgradeBlue()
    {
        if (blueTurret.activeInHierarchy)
        {
            if (pScript.Cash >= blueCost)
            {
                pScript.Cash -= blueCost;
                blueCost *= increment;
                blueLevel++;
                blueT.text = "Upgrade Turret 5 (Current Level: " + blueLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (blueLevel >= maxLevel)
                {
                    blueT.text = "Upgrade Turret 1 (Current Level: Max)";
                    blueUBtn.SetActive(false);
                }
                return;
            }
        }

        else if (!blueTurret.activeInHierarchy)
        {
            pScript.Cash -= blueCost;
            blueTurret.SetActive(true);
            purpleUpgrade.SetActive(true);
            blueLevel += 1;
            blueCost = 500;
            blueT.text = "Upgrade Turret 5 (Current Level: " + blueLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            blueBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }
    }

    public void UnlockUpgradePurple()
    {
        if (purpleTurret.activeInHierarchy)
        {
            if (pScript.Cash >= purpleCost)
            {
                pScript.Cash -= purpleCost;
                purpleCost *= increment;
                purpleLevel++;
                purpleT.text = "Upgrade Turret 6 (Current Level: " + purpleLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (purpleLevel >= maxLevel)
                {
                    purpleT.text = "Upgrade Turret 1 (Current Level: Max)";
                    purpleUBtn.SetActive(false);
                }
                return;
            }
        }

        else if (!purpleTurret.activeInHierarchy)
        {
            pScript.Cash -= purpleCost;
            purpleTurret.SetActive(true);
            blackUpgrade.SetActive(true);
            purpleLevel += 1;
            purpleCost = 500;
            purpleT.text = "Upgrade Turret 6 (Current Level: " + purpleLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            purpleBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }
    }

    public void UnlockUpgradeBlack()
    {
        if (blackTurret.activeInHierarchy)
        {
            if (pScript.Cash >= blackCost)
            {
                pScript.Cash -= blackCost;
                blackCost *= increment;
                blackLevel++;
                blackT.text = "Upgrade Turret 7 (Current Level: " + blackLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (blackLevel >= maxLevel)
                {
                    blackT.text = "Upgrade Turret 7 (Current Level: Max)";
                    blackUBtn.SetActive(false);
                }
                return;
            }
        }

        else if (!blackTurret.activeInHierarchy)
        {
            pScript.Cash -= blackCost;
            blackTurret.SetActive(true);
            whiteUpgrade.SetActive(true);
            blackLevel += 1;
            blackCost = 500;
            blackT.text = "Upgrade Turret 7 (Current Level: " + blackLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            blackBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }
    }

    public void UnlockUpgradeWhite()
    {
        if (whiteTurret.activeInHierarchy)
        {
            if (pScript.Cash >= whiteCost)
            {
                pScript.Cash -= whiteCost;
                whiteCost *= increment;
                whiteLevel++;
                whiteT.text = "Upgrade Turret 8 (Current Level: " + whiteLevel.ToString() + ")";
                cashT.text = "Cash: " + pScript.Cash.ToString();
                CostTextSetter();
                if (whiteLevel >= maxLevel)
                {
                    whiteT.text = "Upgrade Turret 8 (Current Level: Max)";
                    whiteUBtn.SetActive(false);
                }
                return;
            }
        }
        
        else if (!whiteTurret.activeInHierarchy)
        {
            pScript.Cash -= whiteCost;
            whiteTurret.SetActive(true);
            whiteLevel += 1;
            whiteCost = 500;
            whiteT.text = "Upgrade Turret 8 (Current Level: " + whiteLevel.ToString() + ")";
            cashT.text = "Cash: " + pScript.Cash.ToString();
            whiteBtnT.text = "Upgrade";
            CostTextSetter();
            return;
        }

    }

    public void ImpostorsWon()
    {
        redTurret.SetActive(false);
        orangeTurret.SetActive(false);
        yellowTurret.SetActive(false);
        greenTurret.SetActive(false);
        blueTurret.SetActive(false);
        purpleTurret.SetActive(false);
        blackTurret.SetActive(false);
        whiteTurret.SetActive(false);
    }

    public void CostTextSetter()
    {
        redCostT.text = "Cost: " + redCost.ToString();
        orangeCostT.text = "Cost: " + orangeCost.ToString();
        yellowCostT.text = "Cost: " + yellowCost.ToString();
        greenCostT.text = "Cost: " + greenCost.ToString();
        blueCostT.text = "Cost: " + blueCost.ToString();
        purpleCostT.text = "Cost: " + purpleCost.ToString();
        blackCostT.text = "Cost: " + blackCost.ToString();
        whiteCostT.text = "Cost: " + whiteCost.ToString();
    }
}
