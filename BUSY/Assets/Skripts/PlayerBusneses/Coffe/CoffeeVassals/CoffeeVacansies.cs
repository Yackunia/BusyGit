using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeVacansies : DefVacancies
{
    /*
    0 - ������� 30.000
    2 - ������� 15.000
    3 - �����
    4 - ��������� 60.000
    5 - SMM 20.000
     */
    [SerializeField] private Barista barista;
    [SerializeField] private Cleaner cleaner;
    [SerializeField] private Urist urist;
    [SerializeField] private Buchgalter buchgalter;
    [SerializeField] private SMM smm;

    protected override void SalaryPay()
    {
        base.SalaryPay();

        barista.salaryPay();
        cleaner.salaryPay();
        urist.salaryPay();
        buchgalter.salaryPay();
        smm.salaryPay();
    }

 
}
