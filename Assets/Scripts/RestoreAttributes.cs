using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreAttributes : MonoBehaviour
{
    public int value;
    public Slider slider;
    public CharacterAttributes characterAttributes;
    public void AddValue (int value)
    {
        
        if(slider.value+value > 100)
        {

            Debug.Log("too much food");
            //error pop-up when too much
        }
        else
        {
            slider.value += value;
            //consume an item
        }
    }

}
