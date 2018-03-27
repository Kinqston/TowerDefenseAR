using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManeger : MonoBehaviour {

    public static BuildManeger instant;
    public bool _shopTrue;

    private void Awake()
    {
        if (instant != null)
        {
            return;
        }
        instant = this;

    }

    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    //private void Start()
    //{
    //    towerToBuild = tower1;
    //}
    public GameObject posTower;

    private GameObject towerToBuild;
    public GameObject destroyTower;

    public bool getTowerToBuild()
    {
        return _shopTrue;
    }

    public void setTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }

    public void shopTrue()
    {
        _shopTrue = true;
    }


}
