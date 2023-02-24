using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInterfare : MonoBehaviour
{
    [SerializeField] private Transform mainObj;
    public Transform[] points;

    public void StartEdit()
    {
        mainObj.position = points[1].position;
    }

    public void StopEdit()
    {
        mainObj.position = points[0].position;
    }
}
