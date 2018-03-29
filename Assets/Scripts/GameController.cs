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
        gameEnd = false;
    }

    private void EndGame()
    {
        gameEnd = true;
        GameOverUI.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GamePauseUI.SetActive(true);
    }
}
