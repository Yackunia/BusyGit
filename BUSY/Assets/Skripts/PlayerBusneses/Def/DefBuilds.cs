using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class DefBuilds : MonoBehaviour
{
    [SerializeField] private BuildInterfare inter;
    [SerializeField] private DefProducts prod;
    [SerializeField] private DefVacancies vac;

    [Header("Stats")]
    public bool isEnabled;

    public int price;
    public int countOfPeople;
    public int countOfProduct;
    public int[] styles;

    public float fame;
    public float arendeTimer;

    //furniture Coordinates
    [Serializable]
    public class inputers
    {
        public List<Vector2> coordinate = new List<Vector2>();
        public List<float> rotation = new List<float>();
        public List<buildElement> element = new List<buildElement>();

    }

    public inputers[] inp;


    [Header("Build Data")]
    public int idOfBuild;
    public int lastIdF;
    public int fameValue;

    [SerializeField] private DefBuisnes master;

    [SerializeField] private float arendeTimerMax;

    //furniture tipes
    [SerializeField] private GameObject[] inpObjs;

    [SerializeField] private bool isStartingField;

    [Header("Output")]
    [SerializeField] private Text outArendTimer;

    [SerializeField] private GameObject butStart;

    [SerializeField] private Transform parent1;

    protected virtual void Start()
    {
        if (!isStartingField)
        {
            this.enabled = isEnabled;
            butStart.SetActive(true);
            master.fame = fame;
        }


        //furniture spawn
        for (int i = 0; i < inpObjs.Length;i++)
        {
            for (int j = 0; j < inp[i].coordinate.Count; j++)
            {
                inp[i].element.Add(Instantiate(inpObjs[i], new Vector2(inp[i].coordinate[j].x + inter.points[0].position.x -
                    inter.points[1].position.x, inp[i].coordinate[j].y),
                    Quaternion.Euler(0, 0, inp[i].rotation[j]), parent1).GetComponent<buildElement>());

                inp[i].element[j].InputerId = j;
                inp[i].element[j].idOfBuilding = idOfBuild;

            }
        }

    }
    protected virtual void Update()
    {
        ProfitStats();

        Arenda();
    }

    private void ProfitStats()
    {
        for (int i = 0; i < styles.Length; i++) 
            styles[i] = 0;
            
        countOfPeople = 0;
        countOfProduct = 0;
        for (int i = 0; i < inp.Length; i++)
        {
            for (int j = 0; j < inp[i].element.Count; j++)
            {
                countOfPeople += inp[i].element[j].countOfPeople;
                countOfProduct += inp[i].element[j].countOfProduct;
                styles[inp[i].element[j].idOfStyle]++;
            }
        }
        fameValue = Mathf.Min(countOfPeople, countOfProduct);
    }

    private void Arenda()
    {
        if(isEnabled)arendeTimer += master.timer * Time.deltaTime;

        outArendTimer.text = ((int)((arendeTimerMax - arendeTimer)/60/24)).ToString() + "ä. " + 
            ((int)(((arendeTimerMax - arendeTimer) / 60) % 24)).ToString() + "÷. ";

        if (arendeTimerMax < arendeTimer)
        { 
            master.expenses += price;

            arendeTimer = 0;
        }
    }

    public void SetThisBuild()
    {
        isEnabled = true;
    }

    public void destrElem(int id, int InputerId)
    {
        inp[id].coordinate.Remove(inp[id].coordinate[InputerId]);
        inp[id].rotation.Remove(inp[id].rotation[InputerId]);
        inp[id].element.Remove(inp[id].element[InputerId]);

        for(int i = InputerId;i< inp[id].element.Count;i++)
        {
            inp[id].element[i].InputerId--;
        }
    }
}
