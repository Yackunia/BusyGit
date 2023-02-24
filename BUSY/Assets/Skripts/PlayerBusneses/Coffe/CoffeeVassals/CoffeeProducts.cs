using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeProducts : DefProducts
{
    [SerializeField] private Barista barista;
    //������
    /*
     (0) ���	
    #������� ���� 15 �����
    #������ 100 ��
    #��������� ����� 5 �����
	    "�������� ���������/����������
    \============================= 1 ��
     (1) ��������	
    #������� ���� 15 �����
    #������ 75 ��
	    "�������� ���������/����������

     (2) �����
    #������� ���� 15 �����
    #������ 150 ��
	    "�������� ���������/����������
    \============================= 2 ��
     (3) ��������
    #������� ���� 25 �����
	    "�������� ���������/����������

     (4) ���������	
    #������� ���� 20 �����
	    "�������� ���������/����������

     (5) �������������� ����
    #�������������� ����
	    "����������

     (6) ����
    #����
	    "����������
    */
    //�������
    /*
     (0) ���� 
        (0) ��� - 15
        (1) �������� - 15
        (2) ����� - 15
        (3) �������� - 25
        (4) ��������� - 20
        (5) �������������� ���� - 0
        (6) ����� - 0
     (1) ������
        (0) ���	- 0
        (1) �������� - 75
        (2) ����� - 150
        (3) �������� - 0
        (4) ��������� - 0
        (5) �������������� ���� - 0
        (6) ���� - 0
     (2) ������
        (0) ���	- 100
        (1) �������� - 0
        (2) ����� - 0
        (3) �������� - 0
        (4) ��������� - 0
        (5) �������������� ���� - 0 
        (6) ���� - 0
     (3) �����
        (0) ���	- 5
        (1) �������� - 0
        (2) ����� - 0
        (3) �������� - 0 
        (4) ��������� - 0
        (5) �������������� ���� - 0
        (6) ���� - 0 
     (4) ����
        (0) ��� - 0
        (1) �������� - 0
        (2) ����� - 0 
        (3) �������� - 0
        (4) ��������� - 0
        (5) �������������� ���� - 0
        (6) ���� - 1
     (5) ����
        (0) ���	- 0
        (1) �������� - 0
        (2) ����� - 0
        (3) �������� - 0
        (4) ��������� - 0
        (5) �������������� ���� - 1
        (6) ���� - 0
    */

    //��������
    /*
     (0) ���� 10.000 �����
     (1) ������ 10.000 ��
     (2) ������ 3.000 ��
     (3) ����� 1.000 �����
     (4) ���� 50 ��
     (5) ���� 50 ��
    */

    protected override void CheckTovarsToCreate()
    {
        base.CheckTovarsToCreate();
        for (int i = 0; i < sellingTovars.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < buyRaw.Length; j++)
            {
                if (buyRawCount[j] >= recipe[j].counts[i] && sellingTovars[i])
                {
                    count++;
                }
                if (count == buyRaw.Length && barista.onWork) readyTovars[i] = true;
                else readyTovars[i] = false;
            }
        }
    }

    protected override void CheckTovarsToSell()
    {
        oneStepTimer += master.timer * Time.deltaTime * master.fame * build.fameValue;

        if (oneStepTimer > oneStepTimerMax)
        {
            oneStepTimer = 0;
            int id = 0;
            maybeOne = false;
            readyNow = false;

            for (int i = 0; i < readyTovars.Length; i++)
            {
                if (readyTovars[i]) maybeOne = true;
            }
            if (barista.onWork)
            {
                while (!readyNow && maybeOne)
                {
                    id = Random.Range(0, readyTovars.Length);
                    readyNow = readyTovars[id];
                }
                if (readyNow) SellProduct(id);
            }
            //else Debug.Log("Nothing to Sell");
        }
    }

    protected override void SellProduct(int value)
    {
        base.SellProduct(value);
    }
}
