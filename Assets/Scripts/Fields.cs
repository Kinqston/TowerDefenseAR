using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fields : MonoBehaviour {

    public GameObject ShopMenu;
    public static AudioClip audioSellTower;
    public AudioClip audioSell;
    public GameObject SellMenu;
    public bool towerTrue;
    //private int lvlTower;

    private void Start()
    {
        audioSellTower = audioSell;
    }

    private void OnMouseDown()
    {
        if (PlayerStats.Pause == false)
        {
            if (towerTrue == false)
            {
                SellMenu.GetComponent<Canvas>().enabled = false;
                ShopMenu.GetComponent<Canvas>().enabled = true;
                BuildManeger.instant.posTower = gameObject;
            }
        }
        
        
        

        //GameObject towerToBuild = BuildManeger.instant.getTowerToBuild();
        //if (towerToBuild != null)
        //{
        //    Instantiate(towerToBuild, transform.position, transform.rotation);
        //}
    }
}
