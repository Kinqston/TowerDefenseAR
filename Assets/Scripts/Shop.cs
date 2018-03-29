using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    //public TowerCost Tower1;
    //public TowerCost Tower2;

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
        if (PlayerStats.Money >= BuildManeger.instant.tower1.GetComponent<Tower>().Cost)
        {
            BM.setTowerToBuild(BuildManeger.instant.tower1);
            Vector3 posT = new Vector3(BuildManeger.instant.posTower.transform.position.x, 0.7f, BuildManeger.instant.posTower.transform.position.z);
            GameObject TowerNew = Instantiate(BuildManeger.instant.tower1, posT, BuildManeger.instant.posTower.transform.rotation);
            TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;
            //BuildManeger.instant.shopTrue();
            PlayerStats.Money -= 30;
            BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
        }
        gameObject.SetActive(false);
    }

    public void buildTower2()
    {
        if (PlayerStats.Money >= BuildManeger.instant.tower2.GetComponent<Tower>().Cost)
        {
            BM.setTowerToBuild(BuildManeger.instant.tower2);
            Vector3 posT = new Vector3(BuildManeger.instant.posTower.transform.position.x, 0.7f, BuildManeger.instant.posTower.transform.position.z);
            GameObject TowerNew = Instantiate(BuildManeger.instant.tower2, posT, BuildManeger.instant.posTower.transform.rotation);
            TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;            
            PlayerStats.Money -= 50;
            BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
        }
        gameObject.SetActive(false);
    }

    public void sell()
    {
        GameObject Upgrade = GameObject.FindGameObjectWithTag("Destroy");
        Upgrade.GetComponent<Canvas>().enabled = false;

        PlayerStats.Money += BuildManeger.instant.destroyTower.GetComponent<Tower>().Cost / 2;

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
