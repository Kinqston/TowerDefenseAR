using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManeger BM;

    // Use this for initialization
    void Start() {
        BM = BuildManeger.instant;
    }

    // Update is called once per frame
    void Update() {

    }

    public void closeShop()
    {
        // gameObject.SetActive(false);

    }



    public void buildTower1()
    {
        BM.setTowerToBuild(BuildManeger.instant.tower1);
        GameObject TowerNew = Instantiate(BuildManeger.instant.tower1, BuildManeger.instant.posTower.transform.position, BuildManeger.instant.posTower.transform.rotation);
        TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;
        gameObject.SetActive(false);

        //BuildManeger.instant.shopTrue();
        BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
    }

    public void buildTower2()
    {
        BM.setTowerToBuild(BuildManeger.instant.tower2);
        GameObject TowerNew = Instantiate(BuildManeger.instant.tower2, BuildManeger.instant.posTower.transform.position, BuildManeger.instant.posTower.transform.rotation);
        TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;
        gameObject.SetActive(false);
        BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
    }

    public void sell()
    {
        GameObject Upgrade = GameObject.FindGameObjectWithTag("Destroy");
        Upgrade.GetComponent<Canvas>().enabled = false;
        Destroy(BuildManeger.instant.destroyTower);
        BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = false;
        BuildManeger.instant.destroyTower.GetComponent<Tower>().PlaceTower.GetComponent<Fields>().towerTrue = false;
    }

    public void cancel()
    {
        GameObject Upgrade = GameObject.FindGameObjectWithTag("Destroy");
        Upgrade.GetComponent<Canvas>().enabled = false;
    }
   




}
