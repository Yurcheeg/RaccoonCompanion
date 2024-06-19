using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreAttributes : Food
{
    public Slider slider;
    public CharacterAttributes characterAttributes;
    public FoodInventory inventory;
    public DrainScript drainScript;
    private void Awake()
    {
        drainScript = FindObjectOfType<DrainScript>();
        inventory = FindObjectOfType<FoodInventory>();
    }
    private void Start()
    {
        int saturationValue = 5;
        for (int i = 0; i < Enum.GetNames(typeof(FoodList)).Length; i++) { //long thing is just a length of FoodList
            foodSaturation[(FoodList)i] = saturationValue;
            Debug.Log(foodSaturation[(FoodList)i]);
            Debug.Log($"EnumLength{Enum.GetNames(typeof(FoodList)).Length}");
            saturationValue += 5;
        }
        
    }
    public void AddFoodValue (int foodId)
    {
            drainScript.hunger += foodSaturation[(FoodList)foodId];

    }

}
