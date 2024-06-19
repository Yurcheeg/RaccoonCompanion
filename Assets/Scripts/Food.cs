using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour
{

    public enum FoodList
    {
        Banana,
        Blackberry,
        Blackcherry,
        Coconut,
        Orange,
        Watermelon,
        Grapes,
        Plum,
        Lemon
    }
    public static Dictionary<FoodList, int> foodAmount = new Dictionary<FoodList, int>();
    public static Dictionary<FoodList, int> foodPrice = new Dictionary<FoodList, int>();
    public static Dictionary<FoodList, int> foodSaturation = new Dictionary<FoodList, int>();
}
