using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //Stores a reference to itself
    private TurretBluePrint turretToBuild; //So its aware of the turret prefab and the cost of the turret
    private Node selectedTurret;
    public TurretUI turretUI;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one Build Manager in scene!");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update


    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void selectTurret(Node node)
    {
        if(selectedTurret == node)
        {
            DeselectNode();
            return;
        }

        selectedTurret = node;
        turretToBuild = null;
        turretUI.SetTarget(node); //When selecting node, we want a reference to our UI
    

}

    //Called from other methods and change the turret we want to build; sets "turret to build"(private variable) equal to turret we passed in.
    public void SelectTurretToBuild(TurretBluePrint turret) 
    {
        turretToBuild = turret;
        DeselectNode();
    }

   public void DeselectNode()
    {
        selectedTurret = null;
        turretUI.Hide();
    }
    
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
