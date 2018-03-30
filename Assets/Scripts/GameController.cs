using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Castle;
    public static bool gameEnd;
    [Header("Скорость троллей")]
    public float SpeedTrolls;

    public GameObject GameOverUI;
    public GameObject GamePauseUI;

    GameObject ShopUI;
    GameObject UpgradeUI;

    public static GameController GC_ST;

    void SingleTon()
    {
        if (GC_ST == null && GC_ST != this)
        {
            GC_ST = this;
        }
        else
        {
            Destroy(gameObject);
        }
    //    DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingleTon();
    }

    private void Update()
    {
        if (gameEnd)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.Life <= 0)
            EndGame();
    }

    private void Start()
    {
        ShopUI = GameObject.FindGameObjectWithTag("Shop");
        UpgradeUI = GameObject.FindGameObjectWithTag("Destroy");

        gameEnd = false;
        Time.timeScale = 1;
        WaveSpawner.EnemiesAlive = 0;
    }

    public void EndGame()
    {
        gameEnd = true;
        GameOverUI.SetActive(true);
         UpgradeUI.GetComponent<Canvas>().enabled = false;
        ShopUI.GetComponent<Canvas>().enabled = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PlayerStats.Pause = true;
        GamePauseUI.SetActive(true);
       // GameOverUI.GetComponent<Canvas>().enabled = false;
        UpgradeUI.GetComponent<Canvas>().enabled = false;
        ShopUI.GetComponent<Canvas>().enabled = false;
    }
}
