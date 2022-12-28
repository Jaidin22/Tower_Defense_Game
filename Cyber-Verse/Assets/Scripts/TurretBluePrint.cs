using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable] //Will let variables created here be visible in the Inspector
public class TurretBluePrint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int SellAmount()
    {
        return cost / 2;
    }

}
