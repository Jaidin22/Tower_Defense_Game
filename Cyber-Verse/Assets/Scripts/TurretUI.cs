using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    //Keep track of current target (what is the node we're displaying UI for
    private Node target;
    public GameObject ui;


    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellCost;

    

    public void SetTarget(Node t)
    {
        
        target = t;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }

        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }

        sellCost.text = "$" + target.turretBlueprint.SellAmount();

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.Upgrade();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.Sell();
        BuildManager.instance.DeselectNode();
    }

}
