using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FoodInventory : Food
{
    DrainScript drainScript;
    RestoreAttributes restoreAttributes;
    Food food;
    FoodInventory inventory;
    [SerializeField] private List<Button> buttons;
    private void Awake()
    {
        drainScript = FindObjectOfType<DrainScript>();
        restoreAttributes = FindObjectOfType<RestoreAttributes>();
        food = FindObjectOfType<Food>();
        inventory = FindObjectOfType<FoodInventory>(true);
        InitializeInventory();
    }
    private void Start()
    {
        int amountValue =0;
        for (int i = 0; i < Enum.GetNames(typeof(FoodList)).Length; i++)
        {
            if (!foodAmount.ContainsKey((FoodList)i))
            {
                foodAmount[(FoodList)i] = amountValue;
                Debug.Log($"Added key: {(FoodList)i} with value: {foodAmount[(FoodList)i]}");
            }
            else
            {
                Debug.Log($"Key already exists: {(FoodList)i} with value: {foodAmount[(FoodList)i]}");
            }
           /* foodAmount[(FoodList)i] = amountValue; 
            Debug.Log($"amount check: {foodAmount[(FoodList)i]}");*/
        }
        Debug.Log($"Enum.Length: {Enum.GetNames(typeof(FoodList)).Length}");

    }
    void InitializeInventory()
    {
        foreach (FoodList food in foodAmount.Keys)
        {
            foodAmount[food] = 0;
            
        }
        InventoryStats();//test
        UpdateInventory();
    }
    public void InventoryStats()//test
    {
        
      foodAmount[FoodList.Banana] = 4; // for test
        foodAmount[FoodList.Blackberry] = 5;
        foreach (FoodList food in foodAmount.Keys)
        {
            if (foodAmount.TryGetValue(food,out int valueCount))
            {
                Debug.Log($"Food: {food}, Amount: {valueCount}");
            }
        }

      
    }
    private void UpdateInventory()
    {
        for(int i=0;i<buttons.Count;i++)
        {
            FoodList food = (FoodList)i;
            Button button = buttons[i];
            button.gameObject.SetActive(false);
            TMP_Text itemCountText = button.GetComponentInChildren<TMP_Text>();

            if (foodAmount.TryGetValue(food, out int valueCount))
            {
                if (valueCount == 0) 
                { 
                    button.gameObject.SetActive(false);
                    continue;
                }
                button.gameObject.SetActive(true);
                if(itemCountText != null) itemCountText.text = valueCount.ToString();
                Debug.Log($"Updated {food}: Count = {valueCount}, Interactable = {button.interactable}");
            }
        }
    }
    public void AddItem(int foodId)
    {
        FoodList food = (FoodList)foodId;
        //buying an item logic
        if (foodAmount.ContainsKey(food))
        {
            foodAmount[food]++;
            Debug.Log($"Bought {food}");
        }
        else Debug.Log("foodAmount doesn't have this key");
        UpdateInventory();
    }
    
    public void RemoveItem(int foodId)
    {
        
        FoodList food = (FoodList)foodId;
        int saturation = foodSaturation[food];

        if (drainScript.hunger + saturation > 99.9)
        {
            Debug.Log("too much food");
        }
        else if (foodAmount.ContainsKey(food))
        {
            restoreAttributes.AddFoodValue(foodId);
            foodAmount[food]--;
            Debug.Log($"Used {food}");
        }
        UpdateInventory();
    }

}
