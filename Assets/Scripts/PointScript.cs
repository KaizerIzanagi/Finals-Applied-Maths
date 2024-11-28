using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float HP;
    public float MaxHP;
    public float Cash;
    void Start()
    {
        MaxHP = 100;
        HP = MaxHP;
        Cash = 0;
    }

    
    void Update()
    {
        
    }
}
