using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; set; }
    public GameObject GameOver;


    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sus"))
        {
            GameOver.SetActive(true);
        }
        
    }

}
