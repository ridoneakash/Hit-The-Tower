using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shop : MonoBehaviour
{
    public TurretBulePrint standardTurret;
    public TurretBulePrint missileTurret;

    BuildManager buildManager;

     void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileTurret()
    {
        buildManager.SelectTurretToBuild(missileTurret);
    }


}
