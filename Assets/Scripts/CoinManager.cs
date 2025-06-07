using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinText;
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = coins.ToString();
    }
    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }
}
