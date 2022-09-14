using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBulePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool Hasmoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject buildTurretPrefab;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one build manager in screen");
        }

        instance = this;
    }

    
  
   public void BuildTurretOn (Node node)
    {
       if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough money to build That!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition() , Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildTurretPrefab, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 1f);

        Debug.Log("Turret build! Money Left:" + PlayerStats.Money);
       
    }

    public void SelectTurretToBuild( TurretBulePrint turret)
    {
        turretToBuild = turret;
    }

}
