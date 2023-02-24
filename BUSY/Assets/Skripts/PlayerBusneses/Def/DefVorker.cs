using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class DefVorker : MonoBehaviour
{
    [SerializeField] protected Company master;

    [SerializeField] protected DefVacancies vac;
    [SerializeField] protected DefBuisnes bis;
    [SerializeField] protected DefProducts prod;
    [SerializeField] protected DefBuilds build;

    [SerializeField] private int id;

    public bool isWorking;
    public bool isMan;
    public bool onWork;

    public string namePerson;

    public float salary;
    [SerializeField] private float workTimer;
    [SerializeField] private float workTimerMax;
    [SerializeField] private float workTimerMin;


    [Header("Output")]
    [SerializeField] private Text[] outName;
    [SerializeField] private Text[] outSalary;
    [SerializeField] private Text[] outSex;
    [SerializeField] private GameObject[] outOnWork;
    [SerializeField] private GameObject outisWorker;


    protected virtual void Update()
    {
        SetParametersToMaster();
        if (isWorking)
            Job();

        Output();
    }

    private void Output()
    {
        for (int i = 0; i < outName.Length; i++) outName[i].text = namePerson;

        for (int i = 0; i < outSalary.Length; i++) outSalary[i].text = salary.ToString();

        for (int i = 0; i < outOnWork.Length; i++) outOnWork[i].SetActive(!onWork);


        for (int i = 0; i < outSex.Length; i++)
        {
            if (isMan) outSex[i].text = "Мужской";
            else outSex[i].text = "Женский";
        }

        outisWorker.SetActive(!isWorking);
    }

    private void SetParametersToMaster()
    {
        vac.salary[id] = salary;
        vac.isWorking[id] = onWork;
        vac.isWorker[id] = isWorking;
        vac.isMan[id] = isMan;
    }

    protected virtual void Job()
    {
        workTimer += Time.deltaTime * master.GetTimeSpeed();
        if (workTimer > workTimerMax && onWork) Peremena();

        if (workTimer > 60 * 24) workTimer = 0;

        if (workTimer > workTimerMin && !onWork && workTimer<workTimerMax) BackToWork();
    }

    private void BackToWork()
    {
        onWork = true;
    }

    private void Peremena()
    {
        onWork = false;
    }

    public void CreateWorker()
    {
        vac.SetNameAndSex(id);

        namePerson = vac.nameGuy[id];

    }

    public void KillWorker()
    {
        isMan = false;
        onWork = false;
        isWorking = false;
        name = "Сотрудника нет";
    }

    public void salaryPay()
    {
        bis.workersExpencives[id] += salary;
    }
}
