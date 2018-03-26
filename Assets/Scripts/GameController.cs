using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Castle;

    [Header("Скорость троллей")]
    public float SpeedTrolls;

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
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingleTon();
    }
	
}
