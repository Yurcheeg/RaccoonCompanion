using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Data;


public class DrainScript : MonoBehaviour
{

    public float hunger;
    public float maxValue = 100;
    float cleanliness;
    float happiness;
    public CharacterAttributes characterHunger;//ew
    public CharacterAttributes characterCleanliness;
    public CharacterAttributes characterHappiness;
    Coin coin;
    //public TMP_Text hungerText;
    private const float drainRate = 100f/86400f; // 100hunger would drain over 24 hours
    private const float highHungerDrainMultiplier = 12f;
    private void Awake()
    {
        coin = FindObjectOfType<Coin>(true);
    }
    private void Start()
    {
        //ResetValues();//uncomment for testing
        LoadSystem();
        InvokeRepeating("DrainBars", 1f, 1f);
    }
    //drains the values and print the value of it's not smaller than 1
    private void DrainBars()
    {
        ApplyDrain();
        Debug.Log($"Hunger after drain: {hunger}");
        Debug.Log($"Cleanliness after drain: {cleanliness}");
        //UpdateHungerText();
        characterHunger.SetValue(maxValue - hunger);
        characterCleanliness.SetValue(maxValue - cleanliness);//i saw a problem the day after i wrote this code
        characterHappiness.SetValue(maxValue - happiness);
        SaveSystem();
    }

    private void ApplyDrain()
    {
        if (hunger > 70)
        {
            hunger = Mathf.Max(0, hunger - drainRate * highHungerDrainMultiplier);// drains 12x if more than 70% hunger
        }
        else
        {
            hunger = Mathf.Max(0, hunger - drainRate);
        }
        cleanliness = Mathf.Max(0, cleanliness - drainRate);
        happiness = Mathf.Max(0, happiness - drainRate);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
           SaveSystem();
        }
    }
    private void OnApplicationQuit()
    {
        SaveSystem();
    }
    
    private void SaveSystem()
    {
        //saves every value and date
        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Cleanliness",cleanliness);
        PlayerPrefs.SetFloat("Happiness",happiness);
        PlayerPrefs.SetString("LastPlayed", DateTime.Now.ToBinary().ToString()); //binary just saves everything down to the tick
        PlayerPrefs.SetInt("Balance",Coin.balance);
        //need to save food amount somehow
        PlayerPrefs.Save();
    }

    private void LoadSystem()
    {
        hunger = PlayerPrefs.GetFloat("Hunger", 100);
        cleanliness = PlayerPrefs.GetFloat("Cleanliness", 100);
        happiness = PlayerPrefs.GetFloat("Happiness", 100);
        Coin.balance = PlayerPrefs.GetInt("Balance", 0);
        coin.BalanceUpdate();
        if (PlayerPrefs.HasKey("LastPlayed"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("LastPlayed"));
            DateTime lastPlayed = DateTime.FromBinary(temp);
            TimeSpan timeAway = DateTime.Now  - lastPlayed;
            float secondsAway = (float)timeAway.TotalSeconds;
            //secondsAway = 0;//uncommend for testing
            Debug.Log($"Seconds away: {secondsAway}");

            float hungerDrain = (hunger > 70) ? highHungerDrainMultiplier * drainRate : drainRate;
            hunger = Mathf.Max(0, hunger - hungerDrain * secondsAway);
            cleanliness = Mathf.Max(0, cleanliness - drainRate * secondsAway);
            happiness = Mathf.Max(0, happiness - drainRate * secondsAway);
            Debug.Log($"Hunger after time away: {hunger}"); 
        }

    }
    /*private void UpdateHungerText()
    {
        //hungerText.text = "hunger: " + hunger;
        Debug.Log($"Updated hunger text: {hungerText.text}");  
    }*/

    private void ResetValues()
    {
        hunger = maxValue;
        cleanliness = maxValue;
        happiness = maxValue;
        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Cleanliness", cleanliness);
        PlayerPrefs.SetFloat("Happiness", happiness);
        PlayerPrefs.SetString("LastPlayed", DateTime.Now.ToBinary().ToString()); //binary just saves everything down to the tick
        PlayerPrefs.Save();
    }
}
