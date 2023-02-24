using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoffeeBotData
{
    public string nameOfBuisness;
    public string typeOfStyle;

    public float profit;
    public float expenses;
    public float fame;

    public int logo;

    public CoffeeBotData(CoffeeBot coffee)
    {
        nameOfBuisness = coffee.nameOfBuisness;
        typeOfStyle = coffee.typeOfStyle;

        profit = coffee.profit;
        expenses = coffee.expenses;
        fame = coffee.fame;

        logo = coffee.logo;
    }
}
