using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TMP_Text coinText;
    public static int balance;
    private void Start()
    {
        BalanceUpdate();
    }
    public void BalanceUpdate ()
    {
        coinText.text = balance.ToString();
    }
    public void CoinAdd(int value)
    {
        balance += value;
        BalanceUpdate();
    }
    public void BalanceCheck(int value)
    {
        if (balance - value < 0)
        {
            Debug.Log("Your balance is low");
            throw new InsufficientBalanceException("balance is low :(");
        }
        else CoinRemove(value);
    }
    private void CoinRemove(int value) // is only meant to be called by BalanceCheck
    {
        balance -= value;
        BalanceUpdate();

    }

}
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {

    }
}