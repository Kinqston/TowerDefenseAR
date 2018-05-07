using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    //public TowerCost Tower1;
    //public TowerCost Tower2;

    BuildManeger BM;
    GameObject ShopUI;
    GameObject UpgradeUI;
    public Transform parent;

    private AudioSource soundBuild;

    public AudioClip songSell;

    // Use this for initialization
    void Start() {
        BM = BuildManeger.instant;
        ShopUI = GameObject.FindGameObjectWithTag("ShopTag");
        UpgradeUI = GameObject.FindGameObjectWithTag("Upgrade");
    }
    // Update is called once per frame
    void Update() {

    }

    public void closeShop()
    {
        ShopUI.GetComponent<Canvas>().enabled = false;    
    }

    public void cancel()
    {
        UpgradeUI.GetComponent<Canvas>().enabled = false;
    }


    public void buildTower1()
    {
        if (PlayerStats.Money >= BuildManeger.instant.tower1.GetComponent<Tower>().Cost)
        {
            BM.setTowerToBuild(BuildManeger.instant.tower1);
            
            Vector3 posT = new Vector3(BuildManeger.instant.posTower.transform.position.x, BuildManeger.instant.posTower.transform.position.y+0.0138f, BuildManeger.instant.posTower.transform.position.z);

            Quaternion Rot;
            Rot = BuildManeger.instant.posTower.transform.rotation;
            Rot.x = 0;
            Rot.y = 0;

            GameObject TowerNew = Instantiate(BuildManeger.instant.tower1, posT, new Quaternion(0,0,0,0));
            TowerNew.transform.SetParent(parent);
            TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;
            //BuildManeger.instant.shopTrue();
            PlayerStats.Money -= 30;
            BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
            soundBuild = BuildManeger.instant.posTower.GetComponent<AudioSource>();
            soundBuild.Play();
        }
        ShopUI.GetComponent<Canvas>().enabled = false;
    }

    public void buildTower2()
    {
        if (PlayerStats.Money >= BuildManeger.instant.tower2.GetComponent<Tower>().Cost)
        {
            BM.setTowerToBuild(BuildManeger.instant.tower2);
            Vector3 posT = new Vector3(BuildManeger.instant.posTower.transform.position.x, BuildManeger.instant.posTower.transform.position.y + 0.0138f, BuildManeger.instant.posTower.transform.position.z);
            GameObject TowerNew = Instantiate(BuildManeger.instant.tower2, posT, new Quaternion(0, 0, 0, 0));
            TowerNew.transform.SetParent(parent);
            TowerNew.GetComponent<Tower>().PlaceTower = BuildManeger.instant.posTower;            
            PlayerStats.Money -= 50;
            BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = true;
            soundBuild = BuildManeger.instant.posTower.GetComponent<AudioSource>();
            soundBuild.Play();
        }
        ShopUI.GetComponent<Canvas>().enabled = false;
    }

    public void sell()
    {
        UpgradeUI.GetComponent<Canvas>().enabled = false;

        PlayerStats.Money += BuildManeger.instant.destroyTower.GetComponent<Tower>().Cost / 2;

        Destroy(BuildManeger.instant.destroyTower);
        BuildManeger.instant.posTower.GetComponent<Fields>().towerTrue = false;
        BuildManeger.instant.destroyTower.GetComponent<Tower>().PlaceTower.GetComponent<Fields>().towerTrue = false;

        soundBuild = BuildManeger.instant.posTower.GetComponent<AudioSource>();
        soundBuild.clip = Fields.audioSellTower;
        soundBuild.Play();
    }

    
   




}
