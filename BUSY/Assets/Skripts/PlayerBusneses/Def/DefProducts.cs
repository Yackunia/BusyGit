using UnityEngine;
using UnityEngine.UI;

public abstract class DefProducts : MonoBehaviour
{
    //другие скрипты
    [SerializeField] protected DefBuisnes master;
    [SerializeField] private DefVacancies vacancies;
    [SerializeField] protected DefBuilds build;
    
    [Header("Stats")]
    public bool[] sellingTovars;
    public bool[] readyTovars;
    protected bool readyNow;
    protected bool maybeOne;

    [SerializeField] private int[] sellingTovarsPrice;

    [Header("goodsTimers")]
    [SerializeField] protected float oneStepTimer;
    [SerializeField] protected float oneStepTimerMax;
    [System.Serializable]
    public class recipes
    {
        public int[] counts;
    }

    public recipes[] recipe;

    [Header("Stats")]
    public bool[] buyRaw;

    public int[] buyRawCount;
    public int[] buyRawSize;

    [SerializeField] private int[] buyRawPrice;

    [Header("doingTimers")]
    public float[] buyRawTimer;
    public float[] buyRawTimerMax;

    [Header("Output")]
    [SerializeField] private GameObject[] outSellingTovars;
    [SerializeField] private GameObject[] outReadyTovars;

    [SerializeField] private Text[] outRawCount;
    [SerializeField] private Text[] outTimerRaw;

    [System.Serializable]
    public class Outer
    {
        public GameObject[] innerArray;
    }

    public Outer[] outBuingRaw;

    private void Update()
    {
        CheckBuyinTovars();
        CheckTovarsToSell();
        CheckTovarsToCreate();

        OutPutmain();
    }

    #region Earning
    protected virtual void CheckTovarsToCreate()
    {
        
    }

    private void CheckBuyinTovars()
    {
        for (int i = 0; i < buyRaw.Length; i++)
        {
            if (buyRaw[i]) buyRawTimer[i] += master.timer * Time.deltaTime;

            if (buyRawTimer[i] > buyRawTimerMax[i])
            {
                buyRawCount[i] += buyRawSize[i];
                buyRawTimer[i] = 0;
                master.rawExpences[i] += buyRawPrice[i];
                master.rawCounts[i]++;
            }
        }
    }

    protected virtual void CheckTovarsToSell()
    {
        

    }

    protected virtual void SellProduct(int value)
    {
        for (int i = 0; i < buyRawCount.Length; i++)
        {
            buyRawCount[i] -= recipe[i].counts[value];
        }
        master.productProfit[value] += sellingTovarsPrice[value];
        master.productCounts[value]++;
    }
    #endregion

    #region Output
    private void OutPutmain()
    {
        for (int i = 0; i < buyRaw.Length; i++)
        {
            for (int j = 0; j < sellingTovars.Length; j++)
            {
                if (recipe[i].counts[j] != 0)
                {
                    for (int l = 0; l < outBuingRaw[i].innerArray.Length; l++)
                    {
                        if (recipe[i].counts[j] < buyRawCount[i]) outBuingRaw[i].innerArray[l].SetActive(false);
                        else outBuingRaw[i].innerArray[l].SetActive(true);
                    }
                }
            }

            outRawCount[i].text = buyRawCount[i].ToString() + " едениц";

            outTimerRaw[i].text = ((buyRawTimerMax[i] - buyRawTimer[i]) / 60).ToString() + " ч.";
        }

        for (int i = 0; i < sellingTovars.Length; i++)
        {
            outSellingTovars[i].SetActive(sellingTovars[i]);
            outReadyTovars[i].SetActive(!readyTovars[i]);
        }
    }

    public void StartBuyRaw(int id)
    {
        buyRaw[id] = true;
    }
    public void StopBuyRaw(int id)
    {
        buyRaw[id] = false;
    }
    public void StartSellTovar(int id)
    {
        sellingTovars[id] = true;
    }
    public void StopSellTovar(int id)
    {
        sellingTovars[id] = false;
    }
    #endregion
}
