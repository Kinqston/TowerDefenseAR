using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Life;
    public int StartMoney;
    public int Startlife;
    public static int Rounds;
    public static bool Pause;

    void Start()
    {
        Pause = false;
        Rounds = 0;
        Money = StartMoney;
        Life = Startlife;
    }

}
