using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Renderer hoverRender;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color mouseExitColor;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffSet;

    BuildManager buildManager;



    
    void Start()
    {
        hoverRender = GetComponent<Renderer>();
        mouseExitColor = hoverRender.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

     void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
        if (buildManager.Hasmoney)
        {
            hoverRender.material.color = hoverColor;
        }
        else
        {
            hoverRender.material.color = notEnoughMoneyColor;
        }
    }

     void OnMouseExit()
    {
        hoverRender.material.color = mouseExitColor;
    }

     void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if( turret != null)
        {
            Debug.Log("You cannot build there!");
            return;
        }

        buildManager.BuildTurretOn(this);

    }
}
