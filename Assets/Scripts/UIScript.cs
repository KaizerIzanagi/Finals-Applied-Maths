using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject TitleScreen, MainGame, Upgrade, GameOver;
    public GameObject enemySpawner, turrets;
    public TextMeshProUGUI cashT, hpT, waveT, gameOverT;

    public PointScript pScript;
    public UpgradeScript uScript;
    public EnemyGenerator eScript;
    void Start()
    {
        TitleScreen.SetActive(true);
        pScript = GetComponent<PointScript>();
        uScript = GetComponent<UpgradeScript>();
        eScript = FindAnyObjectByType<EnemyGenerator>();
    }

    public void Update()
    {
        hpT.text = "HP: " + pScript.HP.ToString();
        cashT.text = "Cash: " + pScript.Cash.ToString();
        waveT.text = "Wave: " + eScript.waveCount.ToString();
    }

    public void StartGame()
    {
        MainGame.SetActive(true);
        TitleScreen.SetActive(false);
        eScript.gameStart += 1;
        turrets.SetActive(true);
    }

    public void UpgradeMenu()
    {
        Upgrade.SetActive(true);
        MainGame.SetActive(false);
        uScript.CostTextSetter();
        uScript.cashT.text = "Cash: " + pScript.Cash.ToString();
    }

    public void BackButton()
    {
        Upgrade.SetActive(false);
        MainGame.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
