using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TMP_Text coinText;
    public static int balance=100;
    
    public void CoinAdd(int value)
    {
        balance += value;
        coinText.text = balance.ToString();
    }
    public void BalanceCheck(int value)
    {
        if (balance - value < 0)
        {
            Debug.Log("Your balance is low");
        }
        else CoinRemove(value);
    }
    public void CoinRemove(int value)
    {
        balance -= value;
        coinText.text = balance.ToString();
    }

}
