using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Company : MonoBehaviour
{
    [Header("Company Stats")]
    public string companyName;
    public Dictionary<string, float> companyBuisnesses = new Dictionary<string, float>();
    //в настоящий момент поддерживается: Coffee

    public float valueOfMoney;
    public float profit;
    public float expenses;
    public float moneyFactor;
    public float globalTime;

    public int logoID;

    [Header("Money")]   
    [SerializeField] private float timeSpeed;
    [SerializeField] private float moneyTimer;
    [SerializeField] private float moneyTimeMax;

    [Header("Output")]
    [SerializeField] private Text outputMoneyText;
    [SerializeField] private Text outputNameText;
    [SerializeField] private Text outputTimeText;


    [SerializeField] private Image outputLogoImage;

    [Header("CompanyData")]
    [SerializeField] private Sprite[] logoSprites;

    [SerializeField] private float startKapital;
    [SerializeField] private float globalTimeEnd;


    [Header("Buisnesses")]
    private bool isCoffee = false;

    [SerializeField] private Coffee coffee;



    private void Start()
    {
        AddNewBuisness("Coffee");

        LoadCompany();

        ReturnStatsStart();
    }

    private void Update()
    {
        ReturnStatsUpd();
        SetBuisnessParameters();

        Earnings();

        ReturnTime();
    }

    private void ReturnTime()
    {
        globalTime += timeSpeed * Time.deltaTime;
        outputTimeText.text = (((int)(globalTime / 60))).ToString() + ':' +(((int)(globalTime % 60))).ToString();

        if (globalTime >= globalTimeEnd) globalTime = 0;
    }

    #region Earning
    private void Earnings()
    {
        //valueOfMoney
        float timerMoney = 0f;
        foreach(var money in companyBuisnesses)
        {
            timerMoney += money.Value;
        }
        valueOfMoney = timerMoney + startKapital;
        
    }
    #endregion

    #region Output

    private void ReturnStatsUpd()
    {
        outputMoneyText.text = valueOfMoney.ToString();
    }

    private void ReturnStatsStart()
    {
        outputLogoImage.sprite = logoSprites[logoID];
        outputNameText.text = companyName;
    }
    #endregion

    #region Setters\Getters
    public void SetName(string newName)
    {
        companyName = newName;
    }

    public void SetLogo(int newLogoID)
    {
        logoID = newLogoID;
    }

    public void SetTimeSpeed(float newSpeed)
    {
        timeSpeed = newSpeed;
    }

    public float GetTimeSpeed()
    {
        return timeSpeed;
    }
    #endregion

    #region WorkWithBuisnesses

    public void AddNewBuisness(string newBuisnessName)
    {
        if (newBuisnessName == "Coffee")
        {
            CreateCoffe();
        }
    }

    public void CreateCoffe()
    {
        isCoffee = true;
        companyBuisnesses.Add("Coffee", coffee.profit - coffee.expenses);
    }

    private void SetBuisnessParameters()
    {
        if (companyBuisnesses.ContainsKey("Coffee") && isCoffee) companyBuisnesses["Coffee"] = (coffee.profit - coffee.expenses);
    }

    #endregion

    #region SaveSystem
    public void SaveCompany()
    {
        SaveData.SaveCompanyData(this);
    }

    public void LoadCompany()
    {
        CompanyData data = SaveData.LoadCompanyData();

        companyName = data.companyNameData;

        valueOfMoney = data.valueOfMoneyData;
        profit = data.profitData;
        expenses= data.expensesData;
        moneyFactor = data.moneyFactorData;

        logoID = data.logoData; 
    }

    public void DestroySave()
    {
        SaveData.DestroyCompanyData();
    }
    #endregion
}
