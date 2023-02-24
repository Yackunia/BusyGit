using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class DefBuisnes : MonoBehaviour
{
    public Company master;

    [Header("Buisness Stats =========================")]

    public string nameOfBuisness;
    public string typeOfStyle;

    public float profit;
    public float expenses;
    public float fame;

    public int logo;

    //expences
    public float[] rawExpences;
    public float[] rawCounts;
    public float[] workersExpencives;
    //разбиение массива:
    /*
        1 - Мебель
        2 - Стены и пол
        3 - Доставки
     */
    public float[] serviceExpencies;

    //profit
    public float[] productProfit;
    public float[] productCounts;

    //arenda
    public bool[] isArenda;

    [Header("Buisness Data ====================")]
    [SerializeField] private Sprite[] logoSprites;
    [SerializeField] private DefBuilds[] arendaSkripts;

    [Header("Earning =========================")]
    public float timer;

    [Header("Output  =========================")]
    [SerializeField] private Image[] outputLogoImage;

    [SerializeField] private Text[] outputNameText;
    [SerializeField] private Text[] outputProfitText;
    [SerializeField] private Text[] outputExpensesText;
    [Space]
    //profit
    [SerializeField] private Text[] outputProductsProfitTexts;
    [SerializeField] private Text[] outputProductsCountTexts;
    //expences
    [SerializeField] private Text[] outputRawExpencesTexts;
    [SerializeField] private Text[] outputRawCountsTexts;
    [SerializeField] private Text[] outputServiceExpenciesTexts;
    [SerializeField] private Text[] outputWorkersExpencivesTexts;

    protected virtual void Start()
    {
        ReturnStatsStart();

        for(int i = 0; i < isArenda.Length; i++)
        {
            arendaSkripts[i].GameObject().SetActive(isArenda[i]);
            arendaSkripts[i].enabled = isArenda[i];
        }
    }

    protected virtual void Update()
    {
        Earning();
        ReturnStatsUpd();
    }

    #region Output
    private void ReturnStatsStart()
    {
        for(int i = 0; i < outputLogoImage.Length; i++)
        {
            outputLogoImage[i].sprite = logoSprites[logo];
        }
        for (int i = 0; i < outputNameText.Length; i++)
        {
            outputNameText[i].text = nameOfBuisness;
        }
    }
    private void ReturnStatsUpd()
    {
        for (int i = 0; i < outputProfitText.Length; i++)
        {
            outputProfitText[i].text = profit.ToString();
        }
        for (int i = 0; i < outputExpensesText.Length; i++)
        {
            outputExpensesText[i].text = expenses.ToString();
        }


        for (int i = 0; i < outputProductsProfitTexts.Length; i++)
        {
            outputProductsProfitTexts[i].text = productProfit[i].ToString();
            outputProductsCountTexts[i].text = productCounts[i].ToString();
        }
        for (int i = 0; i < outputRawExpencesTexts.Length; i++)
        {
            outputRawCountsTexts[i].text = rawCounts[i].ToString();
            outputRawExpencesTexts[i].text = rawExpences[i].ToString();
        }
        for (int i = 0; i < outputServiceExpenciesTexts.Length; i++)
        {
            outputServiceExpenciesTexts[i].text = serviceExpencies[i].ToString();
        }
        for (int i = 0; i < outputWorkersExpencivesTexts.Length; i++)
        {
            outputWorkersExpencivesTexts[i].text = workersExpencives[i].ToString();
        }

    }


    #endregion

    #region Earning

    private void Earning()
    {
        Expences();
        Profit();
        

        timer = master.GetTimeSpeed();
    }

    private void Profit()
    {
        float prod = 0;

        for (int i = 0; i < productCounts.Length; i++)
        {
            prod += productProfit[i];
        }
        profit = prod;
    }

    private void Expences()
    {
        float raw = 0;
        for (int i = 0; i < rawCounts.Length; i++)
        {
            raw += rawExpences[i];
        }
        float serv = 0;
        for (int i = 0; i < serviceExpencies.Length; i++)
        {
            serv += serviceExpencies[i];
        }
        float worker = 0;
        for (int i = 0; i < workersExpencives.Length; i++)
        {
            worker += workersExpencives[i];
        }
        expenses = raw + worker + serv;
    }
    #endregion

    #region Setters/Getters

    public void SetIsArenda(int i)
    {
        if (i < 0) isArenda[-1 * (i - 1)] = false;
        else isArenda[(i - 1)] = true;
    }
    public void ChangeName(string newName)
    {
        nameOfBuisness = newName;
    }

    public void ChangeLogoID(int newLogo)
    {
        logo = newLogo;
    }

    public void SetFame(float newFame)
    {
        fame = newFame;
    }




    #endregion
}
