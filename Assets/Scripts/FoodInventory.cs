using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FoodInventory : MonoBehaviour
{

    [SerializeField] private List<Button> buttons;
    private Dictionary<Food, int> foodAmount = new Dictionary<Food, int>();
    private void Awake()
    {
        InitializeInventory();
    }
    enum Food
    {
        Apple,
        Banana,
        Strawberry,
        Watermelon,
        Orange,
        Lemon,
        Cherry,
        Pear,
        Plum
    }
    void InitializeInventory()
    {
        foreach (Food food in foodAmount.Keys)
        {
            foodAmount[food] = 0;
            
        }
        InventoryStats();//test
        UpdateInventory();
    }
    public void InventoryStats()//test
    {
        
      foodAmount[Food.Apple] = 4; // for test
        foreach (Food food in foodAmount.Keys)
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
            Food food = (Food)i;
            Button button = buttons[i];
            button.gameObject.SetActive(false);
            TMP_Text itemCountText = button.GetComponentInChildren<TMP_Text>();

            if (foodAmount.TryGetValue(food, out int valueCount))
            {
                button.gameObject.SetActive(true);
                itemCountText.text = valueCount.ToString();
                Debug.Log($"Updated {food}: Count = {valueCount}, Interactable = {button.interactable}");
            }
        }
    }
    public void AddItem(int foodId)
    {
        Food food = (Food)foodId;
        if(foodAmount.ContainsKey(food)) {
            foodAmount[food]++;
            Debug.Log($"Bought {food}");
        }
        UpdateInventory();
    }

}
