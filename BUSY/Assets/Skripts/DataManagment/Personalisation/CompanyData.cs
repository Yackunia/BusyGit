using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompanyData 
{
    public string companyNameData;

    public float valueOfMoneyData;
    public float profitData;
    public float expensesData;
    public float moneyFactorData;

    public int logoData;


    public CompanyData(Company company)
    {
        companyNameData = company.companyName;

        valueOfMoneyData = company.valueOfMoney;
        profitData = company.profit;
        expensesData = company.expenses;
        moneyFactorData = company.moneyFactor;

        logoData = company.logoID;
    }

}
