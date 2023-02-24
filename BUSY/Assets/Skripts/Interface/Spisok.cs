using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spisok : MonoBehaviour
{
    public bool isDouble;
    [SerializeField] private bool[] isEnabled;

    [SerializeField] private float distance;

    [SerializeField] private GameObject[] enabledGameObj;
    [SerializeField] private GameObject[] disabledGameObj;

    [SerializeField] private RectTransform[] enabledObj;
    [SerializeField] private RectTransform[] disabledObj;
    [SerializeField] private Transform[] parents;
    [SerializeField] private Transform[] points;
    [SerializeField] private Transform[] last;


    private void Update()
    {
        if (isDouble) DoubleVoid();
        else MonoVoid();
    }

    public void SetEnabled(int id)
    {
        if (id < 0) isEnabled[-1 * id - 1] = false;
        else isEnabled[id - 1] = true;
    }

    private void MonoVoid()
    {
        last[0] = points[0];
        last[1] = points[1];

        for (int i = 0; i < isEnabled.Length; i++)
        {
            if (isEnabled[i])
            {
                enabledObj[i].parent = parents[0];

                enabledObj[i].localPosition = new Vector2(last[0].localPosition.x,
                last[0].localPosition.y - distance - enabledObj[i].rect.height);

                last[0] = enabledObj[i];
            }
            else
            {
                enabledObj[i].parent = parents[1];

                enabledObj[i].localPosition = new Vector2(last[1].localPosition.x,
                    last[1].localPosition.y - distance - enabledObj[i].rect.height);

                last[1] = enabledObj[i];
            }

        }
    }

    private void DoubleVoid()
    {
        last[0] = points[0];
        last[1] = points[1];

        for (int i = 0; i < isEnabled.Length; i++)
        {
            if (isEnabled[i])
            {
                enabledGameObj[i].SetActive(true);
                disabledGameObj[i].SetActive(false);

                enabledObj[i].localPosition = new Vector2(last[0].localPosition.x,
                last[0].localPosition.y - distance - enabledObj[i].rect.height);

                last[0] = enabledObj[i];
            }
            else
            {
                enabledGameObj[i].SetActive(false);
                disabledGameObj[i].SetActive(true);

                disabledObj[i].localPosition = new Vector2(last[1].localPosition.x,
                    last[1].localPosition.y - distance - disabledObj[i].rect.height);

                last[1] = disabledObj[i];
            }

        }
    }
}
