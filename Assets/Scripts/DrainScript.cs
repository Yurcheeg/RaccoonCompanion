using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;
using System.Data;
using TMPro.EditorUtilities;
using TMPro;

public class DrainScript : MonoBehaviour
{

    float hunger;
    float cleanliness;
    float happiness;
    [SerializeField] public TMP_Text hungerText;
    private const float drainRate = 100f/86400f; // 100hunger would drain over 24 hours
    private void Start()
    {
        //ResetValues();//uncomment for testing
        LoadSystem();
        InvokeRepeating("DrainBars", 1f, 1f);
    }
    //drains the values and print the value of it's not smaller than 1
    private void DrainBars()
    {
        if (hunger < 70) 
        {
            hunger = Mathf.Max(0, hunger - drainRate);
        }
        else
        {
            hunger = Mathf.Max(0, hunger - drainRate*12);// drains 12x if more than 70% hunger
        }
        cleanliness = Mathf.Max(0, cleanliness-drainRate);
        happiness = Mathf.Max(0, happiness-drainRate);
        Debug.Log($"Hunger after drain: {hunger}");  // Debug log for hunger value
        UpdateHungerText();
        SaveSystem();
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
        PlayerPrefs.Save();
    }
    private void LoadSystem()
    {
        hunger = PlayerPrefs.GetFloat("Hunger", 100);
        cleanliness = PlayerPrefs.GetFloat("Cleanliness", 100);
        happiness = PlayerPrefs.GetFloat("Happiness", 100);
        if (PlayerPrefs.HasKey("LastPlayed"))
        {
            long temp = Convert.ToInt64(PlayerPrefs.GetString("LastPlayed"));
            DateTime lastPlayed = DateTime.FromBinary(temp);
            TimeSpan timeAway = DateTime.Now  - lastPlayed;
            float secondsAway = (float)timeAway.TotalSeconds;
            //secondsAway = 0;//uncommend for testing
            Debug.Log($"Seconds away: {secondsAway}");
            hunger = Mathf.Max(0, hunger - drainRate * secondsAway);
            cleanliness = Mathf.Max(0, cleanliness - drainRate * secondsAway);
            happiness = Mathf.Max(0, happiness - drainRate * secondsAway);
            Debug.Log($"Hunger after time away: {hunger}");  // Debug log for hunger value after time away
        }

    }
    private void UpdateHungerText()
    {
        hungerText.text = "hunger: " + hunger;
        Debug.Log($"Updated hunger text: {hungerText.text}");  // Debug log for updated text
    }

    private void ResetValues()
    {
        hunger = 100;
        cleanliness = 100;
        happiness = 100;
        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Cleanliness", cleanliness);
        PlayerPrefs.SetFloat("Happiness", happiness);
        PlayerPrefs.SetString("LastPlayed", DateTime.Now.ToBinary().ToString()); //binary just saves everything down to the tick
        PlayerPrefs.Save();
    }
}
