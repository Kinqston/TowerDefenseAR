using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;
    public Text lifeStrange;
    public Text WaveTXT;
    private void Update()
    {
        moneyText.text = PlayerStats.Money.ToString();
        lifeStrange.text = PlayerStats.Life.ToString();
        WaveTXT.text = "Level waves: "+PlayerStats.Rounds.ToString();
    }
}
