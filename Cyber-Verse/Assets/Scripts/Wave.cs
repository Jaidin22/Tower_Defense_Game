using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    public WaveGroup[] enemies;
    public float rate;

    [System.Serializable]
    public class WaveGroup
    {
    public GameObject enemy;
    public int count;
    }

}