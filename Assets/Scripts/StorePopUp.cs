using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
public class StorePopUp : MonoBehaviour
{
    public TMP_Text popUpItemName;
    private int cost;
    public Coin coin;

    public void UpdatePopUpText(StoreItem item)
    {
        popUpItemName.text = "Are you sure you want to buy " + item.itemName;
        cost = item.itemCost;
        
    }
    public void OnButtonClick()
    {
        coin.BalanceCheck(cost);
    }
    


}
