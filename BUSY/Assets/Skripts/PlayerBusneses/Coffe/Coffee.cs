
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : DefBuisnes
{
    
    protected override void Start()
    {      
        LoadCompany();
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }

    #region SaveSystem
    public void SaveCoffee()
    {
        SaveData.SaveCoffeeData(this);
    }

    public void LoadCompany()
    {
        CoffeeData data = SaveData.LoadCoffeeData();

        isArenda = data.isArenda;

        nameOfBuisness = data.nameOfBuisness;
        typeOfStyle = data.typeOfStyle;

        profit = data.profit;
        expenses = data.expenses;
        fame = data.fame;

        logo = data.logo;

       
        //expences
        rawExpences = data.rawExpences;
        rawCounts = data.rawCounts;
        serviceExpencies = data.serviceExpencies;
        workersExpencives = data.workersExpencives;
        //profit
        productProfit = data.productProfit;
        productCounts = data.productCounts;
        
    }

    public void DestroySave()
    {
        SaveData.DestroyCoffeeData();
    }
    #endregion
}
