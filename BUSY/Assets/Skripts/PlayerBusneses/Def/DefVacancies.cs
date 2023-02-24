using UnityEngine;



public abstract class DefVacancies : MonoBehaviour
{
    [SerializeField] private Company master;

    [SerializeField] private float salaryTimer;
    [SerializeField] private float salaryTimerMax;


    [SerializeField] private string[] namesLibraryM;
    [SerializeField] private string[] namesLibraryW;

    [Header("Vac Stats")]

    public bool[] isWorker;
    public bool[] isWorking;
    public bool[] isMan;

    public string[] nameGuy;

    public float[] salary;

    [Header("Letters")]
    public bool[] isAnswering;

    public float[] letterTimers;

    [SerializeField] private float letterTimerMax;

    

    private void Update()
    {
        TimersWork();
    }

   

    #region Earning
    private void TimersWork()
    {
        salaryTimer += master.GetTimeSpeed() * Time.deltaTime;
        if (salaryTimer > salaryTimerMax) SalaryPay();
    }

    protected virtual void SalaryPay()
    {
        salaryTimer = 0;
        //в дочерних классах будут вызываться методы платежей у работников
    }
    #endregion

    

    #region Setters/Getters

    public void SetNameAndSex(int id)
    {
        int sex = UnityEngine.Random.Range(0, 2);
        if (sex == 1)
        {
            isMan[id] = true;
            int newId = UnityEngine.Random.Range(0, namesLibraryM.Length);
            nameGuy[id] = namesLibraryM[newId];
        }
        else
        {
            isMan[id] = false;
            int newId = UnityEngine.Random.Range(0, namesLibraryW.Length);
            nameGuy[id] = namesLibraryW[newId];
        }
    }

    #endregion
}
