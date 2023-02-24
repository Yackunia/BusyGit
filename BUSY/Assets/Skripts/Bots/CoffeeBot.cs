using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBot : DefBuisnes
{
    protected override void Start()
    {
        //SaveCoffee();
        LoadCompany();
        base.Start();
    }
    #region SaveSystem
    public void SaveCoffee()
    {
        SaveData.SaveCoffeeBotData(this);
    }

    public void LoadCompany()
    {
        CoffeeBotData data = SaveData.LoadCoffeeBotData();

        nameOfBuisness = data.nameOfBuisness;
        typeOfStyle = data.typeOfStyle;

        profit = data.profit;
        expenses = data.expenses;
        fame = data.fame;

        logo = data.logo;
    }

    public void DestroySave()
    {
        SaveData.DestroyCoffeeBotData();
    }
    #endregion
}
