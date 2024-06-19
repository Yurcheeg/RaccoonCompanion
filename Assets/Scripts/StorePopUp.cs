using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System;

public class StorePopUp : MonoBehaviour
{
    // public TMP_Text popUpItemName;
    FoodPrice foodPrice;
    public Coin coin;
    [SerializeField] private List<Button> buttons;
    //public Food food;
    public int buttonId;

    private void Awake()
    {
        foodPrice = FindObjectOfType<FoodPrice>();
        coin = FindObjectOfType<Coin>();
    }

    public void GetButtonId(int buttonId)
    {
        this.buttonId = buttonId;
        Debug.Log($"clicked {buttonId}");
        Debug.Log($"clicked {this.buttonId}");
    }

    public void BuyItem()
    {
        Debug.Log($"bought: {buttonId}");
        foodPrice.BuyItem(buttonId);
    }
    


}
