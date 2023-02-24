using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoffeeProducts : DefProducts
{
    [SerializeField] private Barista barista;
    //товары
    /*
     (0) Раф	
    #Молотый кофе 15 грамм
    #Сливки 100 мл
    #Ванильный сахар 5 грамм
	    "Рожковая кофеварка/Кофемашина
    \============================= 1 шт
     (1) Капучино	
    #Молотый кофе 15 грамм
    #Молоко 75 мл
	    "Рожковая кофеварка/Кофемашина

     (2) Латте
    #Молотый кофе 15 грамм
    #Молоко 150 мл
	    "Рожковая кофеварка/Кофемашина
    \============================= 2 шт
     (3) Эспрессо
    #Молотый кофе 25 грамм
	    "Рожковая кофеварка/Кофемашина

     (4) Американо	
    #Молотый кофе 20 грамм
	    "Рожковая кофеварка/Кофемашина

     (5) Бутылированная вода
    #Бутылированная вода
	    "Покупается

     (6) Кола
    #Кола
	    "Покупается
    */
    //рецепты
    /*
     (0) зёрна 
        (0) Раф - 15
        (1) Капучино - 15
        (2) Латте - 15
        (3) Эспрессо - 25
        (4) Американо - 20
        (5) Бутылированная вода - 0
        (6) Колас - 0
     (1) Молоко
        (0) Раф	- 0
        (1) Капучино - 75
        (2) Латте - 150
        (3) Эспрессо - 0
        (4) Американо - 0
        (5) Бутылированная вода - 0
        (6) Кола - 0
     (2) Сливки
        (0) Раф	- 100
        (1) Капучино - 0
        (2) Латте - 0
        (3) Эспрессо - 0
        (4) Американо - 0
        (5) Бутылированная вода - 0 
        (6) Кола - 0
     (3) Сахар
        (0) Раф	- 5
        (1) Капучино - 0
        (2) Латте - 0
        (3) Эспрессо - 0 
        (4) Американо - 0
        (5) Бутылированная вода - 0
        (6) Кола - 0 
     (4) Кола
        (0) Раф - 0
        (1) Капучино - 0
        (2) Латте - 0 
        (3) Эспрессо - 0
        (4) Американо - 0
        (5) Бутылированная вода - 0
        (6) Кола - 1
     (5) Вода
        (0) Раф	- 0
        (1) Капучино - 0
        (2) Латте - 0
        (3) Эспрессо - 0
        (4) Американо - 0
        (5) Бутылированная вода - 1
        (6) Кола - 0
    */

    //предметы
    /*
     (0) зёрна 10.000 грамм
     (1) Молоко 10.000 мл
     (2) Сливки 3.000 мл
     (3) Сахар 1.000 грамм
     (4) Кола 50 шт
     (5) Вода 50 шт
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
