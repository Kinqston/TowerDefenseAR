using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fields : MonoBehaviour {

    public GameObject ShopMenu;
    public GameObject SellMenu;

    public bool towerTrue;
    //private int lvlTower;

    private void OnMouseDown()
    {
        if (towerTrue == false)
        {
            SellMenu.SetActive(false);
            ShopMenu.SetActive(true);
            BuildManeger.instant.posTower = gameObject;      
        }

        
        

        //GameObject towerToBuild = BuildManeger.instant.getTowerToBuild();
        //if (towerToBuild != null)
        //{
        //    Instantiate(towerToBuild, transform.position, transform.rotation);
        //}
    }
}
