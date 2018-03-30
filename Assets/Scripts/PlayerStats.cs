using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Life;
    public int StartMoney;
    public int Startlife;
    public static int Rounds;

    void Start()
    {
        Rounds = 0;
        Money = StartMoney;
        Life = Startlife;
    }

}
