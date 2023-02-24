using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CoffeeBuildsData
{
    public bool isEnabled;

    public int price;

    public float fame;
    public float arendeTimer;


    public List<float> posX1 = new List<float>();
    public List<float> posY1 = new List<float>();

    public List<float> posX2 = new List<float>();
    public List<float> posY2 = new List<float>();

    public List<float> posX3 = new List<float>();
    public List<float> posY3 = new List<float>();

    public List<float> rot1 = new List<float>();

    public List<float> rot2 = new List<float>();

    public List<float> rot3 = new List<float>();


    public CoffeeBuildsData(CoffeeBuilding coffee)
    {
        isEnabled = coffee.isEnabled;

        posX1.Clear();
        posY1.Clear();

        posX2.Clear();
        posY2.Clear();

        posX3.Clear();
        posY3.Clear();

        rot2.Clear();

        rot2.Clear();

        rot3.Clear();

        price = coffee.price;

        fame = coffee.fame;
        arendeTimer = coffee.arendeTimer;
        
        for(int i = 0; i < coffee.inp[0].coordinate.Count; i++)
        {
            posX1.Add(coffee.inp[0].coordinate[i].x);
            posY1.Add(coffee.inp[0].coordinate[i].y);

            rot1.Add(coffee.inp[0].rotation[i]);
        }

        for (int i = 0; i < coffee.inp[1].coordinate.Count; i++)
        {
            posX2.Add(coffee.inp[1].coordinate[i].x);
            posY2.Add(coffee.inp[1].coordinate[i].y);

            rot2.Add(coffee.inp[1].rotation[i]);
        }

        for (int i = 0; i < coffee.inp[2].coordinate.Count; i++)
        {
            posX3.Add(coffee.inp[2].coordinate[i].x);
            posY3.Add(coffee.inp[2].coordinate[i].y);

            rot3.Add(coffee.inp[2].rotation[i]);
        }

    }
}
