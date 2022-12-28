using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color insufficientColor;
    private Renderer render;
    private Color startColor;


    [HideInInspector]
    public GameObject turret; //Node is aware of what turret is on top of it

    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    public Turret1 turr;
    public bool isUpgraded = false;

    public Vector3 positionOffset;

    BuildManager buildManager;
    //Changes a color of the node when the mouse overs over it

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    //Called when we press down on the mouse button
    private void OnMouseDown()
    {
        //Is the UI element over a gameObject?
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

            if(turret != null) //if turret is on already on the node
        {
            buildManager.selectTurret(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;

        }

        BuildTurret(buildManager.GetTurretToBuild());

        buildManager.SelectTurretToBuild(null);
        
    }

    
    private void OnMouseEnter()
    {
        //Is the UI element over a gameObject?
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Highligt different nodes only when we have a turret selected
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney )
        {

            render.material.color = hoverColor;
        }
        else {
            render.material.color = insufficientColor;
        }
        
    }

    private void OnMouseExit()
    {

        render.material.color = startColor;

    }

    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {            
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);//Quaternion.identity- wont rotate at all
        turret = _turret;

        turretBlueprint = blueprint;
    }

    public void Upgrade()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret); //Gets rid of the old turret
       
        //Building upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);//Quaternion.identity- wont rotate at all
        turret = _turret;
        isUpgraded = true;
    }

    public void Sell()
    {
        PlayerStats.Money += turretBlueprint.SellAmount();

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }


}
