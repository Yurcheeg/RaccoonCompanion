using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class FoodPrice : Food
{
    FoodInventory inventory;
    [SerializeField] Coin coin;
    [SerializeField] int buttonId;
    private void Awake()
    {
       // coin = FindObjectOfType<Coin>();
        inventory = FindObjectOfType<FoodInventory>(true);

    }
    private void Start()
    {
        int priceValue = 20;
        for (int i = 0; i < Enum.GetNames(typeof(FoodList)).Length; i++)
        {
            foodPrice[(FoodList)i] = priceValue;
            Debug.Log($"fp check: {foodPrice[(FoodList)i]}");
            priceValue += 20;

        }
        Debug.Log($"Enum.Length: {Enum.GetNames(typeof(FoodList)).Length}");

        var text = GetComponentInChildren<TMP_Text>();
        text.text = foodPrice[(FoodList)buttonId].ToString();
    }
    public void BuyItem(int foodId)
    {
        FoodList food = (FoodList)foodId;
        try
        {
            coin.BalanceCheck(foodPrice[food]);
            inventory.AddItem(foodId);
        }
        catch(InsufficientBalanceException ex)
        {
            Console.WriteLine("Insufficient balance to buy the item: " + ex.Message);
        }
    }
}
