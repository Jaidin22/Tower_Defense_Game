using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint heavyTurret;
    public TurretBluePrint missleLauncher;
    public TurretBluePrint minigun;
    public TurretBluePrint laserTurret;
    public Button standardTurretButton, heavyTurretButton, missleLauncherButton, miniGunButton, laserTurretButton;

    BuildManager buildManager;

    

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;

    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        
        buildManager.SelectTurretToBuild(standardTurret); //Call method "Select turret to build" in build manager; Pass turret we want to build. 
    }

    public void SelectHeavyTurret()
    {
        Debug.Log("Heavy Turret Selected");

        buildManager.SelectTurretToBuild(heavyTurret); 

    }

    public void SelectMissleLauncher()
    {
        Debug.Log("Missle Launcher Selected");
        buildManager.SelectTurretToBuild(missleLauncher);
    }

    public void SelectMiniGun()
    {
        Debug.Log("MiniGun Selected");
        buildManager.SelectTurretToBuild(minigun);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laster Turret Selected");
        buildManager.SelectTurretToBuild(laserTurret);
    }


    private void Update()
    {
        
        if(PlayerStats.Money >= standardTurret.cost)
        {
            standardTurretButton.interactable = true;

        }
        else
        {
            standardTurretButton.interactable = false;
        }

        if (PlayerStats.Money >= heavyTurret.cost)
        {
            heavyTurretButton.interactable = true;

        }
        else
        {
            heavyTurretButton.interactable = false;
        }

        if (PlayerStats.Money >= missleLauncher.cost)
        {
            missleLauncherButton.interactable = true;

        }
        else
        {
            missleLauncherButton.interactable = false;
        }
        if(PlayerStats.Money >= minigun.cost)
        {
            miniGunButton.interactable = true;

        }
        else
        {
            miniGunButton.interactable = false;
        }

        if (PlayerStats.Money >= laserTurret.cost)
        {
            laserTurretButton.interactable = true;

        }
        else
        {
            laserTurretButton.interactable = false;
        }
    }


}
