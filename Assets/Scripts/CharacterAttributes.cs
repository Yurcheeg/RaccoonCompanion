using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttributes : MonoBehaviour
{
    public Slider slider;
    
    public void SetValue (float value)
    {
        slider.value = value;
    }
}
