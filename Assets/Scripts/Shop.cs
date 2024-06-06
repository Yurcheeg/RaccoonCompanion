using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    
    //иницилизация класса BackgroundChanger
    public BacKGroundchanger bacKGroundchanger;

    void Start()
    {
        
    }


    //создание метода для покупки нового заднего фона
    public void BuyNewBackground(int index,string category)
    {

        //замена старого фона на новый купленный
        bacKGroundchanger.BackGroundChanger(index,category);
    }
}
