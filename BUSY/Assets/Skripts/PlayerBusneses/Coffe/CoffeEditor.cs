using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeEditor : MonoBehaviour
{
    [SerializeField] Coffee master;
    [SerializeField] public CoffeeBuilding building;

    [SerializeField] private GameObject[] inputers;
    [SerializeField] private GameObject inputerValue;

    [SerializeField] private Transform parent1;
    [SerializeField] private Transform point;


    [SerializeField] private int[] inpPrices;
    [SerializeField] private int idOfBuild;
    public void newInputer(int id)
    {
        inputerValue = Instantiate(inputers[id], point.position, Quaternion.identity,parent1);
        inputerValue.SendMessage("SetIdOfBuild", idOfBuild);
        master.serviceExpencies[0] += inpPrices[id];
    }
}
