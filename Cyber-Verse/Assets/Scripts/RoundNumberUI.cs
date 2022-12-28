using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumberUI : MonoBehaviour
{
    public Text RoundsText;
   
    // Update is called once per frame
    void Update()
    {
        RoundsText.text = "ROUND " + PlayerStats.Rounds; 
    }
}
