﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int StartMoney;
    void Start()
    {
        Money = StartMoney;
    }
}
