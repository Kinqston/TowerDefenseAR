using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;
    public Text lifeStrange;

    private void Update()
    {
        moneyText.text = PlayerStats.Money.ToString();
        lifeStrange.text = PlayerStats.Life.ToString();
    }

    


}
