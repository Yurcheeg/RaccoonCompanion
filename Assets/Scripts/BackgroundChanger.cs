using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacKGroundchanger : MonoBehaviour
{
    public Image backgroundRenderer;
    public Sprite[] backgroundArr = new Sprite[4];
    private int currentBackgroundIndex = 0;
    private string produktCategory = "BackGround";

    void Start()
    {
        if(backgroundArr.Length>0)
        {
            backgroundRenderer.sprite = backgroundArr[currentBackgroundIndex];
        }
    }

    public void BackGroundChanger(int index,string category)
    {
        if(index >=0 && index < backgroundArr.Length  && category == produktCategory)
        {
            currentBackgroundIndex = index;
            backgroundRenderer.sprite = backgroundArr[currentBackgroundIndex];
        }
    }
}
