using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour
{
    public CurrencyManager currency;
    public Text coinText;

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + currency.coins;
    }
}
