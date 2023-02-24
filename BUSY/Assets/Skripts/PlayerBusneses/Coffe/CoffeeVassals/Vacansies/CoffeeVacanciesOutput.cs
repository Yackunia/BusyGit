using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeVacanciesOutput : MonoBehaviour
{
    [SerializeField] private CoffeeVacansies master;

    [Header("Output")]

    [SerializeField] private GetIsWorker[] getIsWorker;

    [SerializeField] private Text[] getIsMan;

    [SerializeField] private GameObject[] getIsAnswer;

    [Serializable]
    public class OutputName
    {
        public Text[] ind;
    }
    [Serializable]
    public class OutputSalary
    {
        public Text[] ind;
    }
    [Serializable]
    public class GetIsWorker
    {
        public GameObject[] ind;
    }
    public OutputName[] outputName;
    public OutputSalary[] outputSalary;

    private void OutputUpd()
    {

    }
}
