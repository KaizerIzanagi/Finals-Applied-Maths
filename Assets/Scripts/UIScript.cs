using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject TitleScreen, MainGame, Upgrade, GameOver;
    public GameObject enemySpawner, turrets;
    void Start()
    {
        TitleScreen.SetActive(true);
    }

    public void StartGame()
    {
        MainGame.SetActive(true);
        TitleScreen.SetActive(false);
        enemySpawner.SetActive(true);
        turrets.SetActive(true);
    }

    public void UpgradeMenu()
    {
        Upgrade.SetActive(true);
        MainGame.SetActive(false);
    }

    public void BackButton()
    {
        Upgrade.SetActive(false);
        MainGame.SetActive(true);
    }

    public void Retry()
    {
        MainGame.SetActive(true);
    }
    
}
