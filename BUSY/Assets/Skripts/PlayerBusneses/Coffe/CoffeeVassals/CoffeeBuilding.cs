using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBuilding : DefBuilds
{

    protected override void Start()
    {
        Load();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    #region SaveSystem
    public void SaveBuild()
    {
        SaveData.SaveCoffeeBuildData(this);
    }

    public void Load()
    {
        CoffeeBuildsData data = SaveData.LoadCoffeBuildData(idOfBuild);

        isEnabled = data.isEnabled;

        price = data.price;

        fame = data.fame;
        arendeTimer = data.arendeTimer;
        for (int i = 0; i < inp.Length; i++)
        {
            inp[i].coordinate.Clear();
        }
        for (int i = 0; i < data.posX1.Count; i++)
            inp[0].coordinate.Add(new Vector2(data.posX1[i], data.posY1[i]));
        for (int i = 0; i < data.posX2.Count; i++)
            inp[1].coordinate.Add(new Vector2(data.posX2[i], data.posY2[i]));
        for (int i = 0; i < data.posX3.Count; i++)
            inp[2].coordinate.Add(new Vector2(data.posX3[i], data.posY3[i]));

        for (int i = 0; i < inp.Length; i++)
        {
            inp[i].rotation.Clear();
        }
        for (int i = 0; i < data.rot1.Count; i++)
            inp[0].rotation.Add(data.rot1[i]);
        for (int i = 0; i < data.rot2.Count; i++)
            inp[1].rotation.Add(data.rot2[i]);
        for (int i = 0; i < data.rot3.Count; i++)
            inp[2].rotation.Add(data.rot3[i]);

    }

    public void DestroySave()
    {
        SaveData.DestroyCoffeeBuildData();
    }

    internal void ChangeCoordinatesOfFurniture(int idOfInputer, float x, float y,float r, buildElement build)
    {
        inp[idOfInputer].coordinate.Add(new Vector2(x, y));
        inp[idOfInputer].rotation.Add(r);
        inp[idOfInputer].element.Add(build);
        SaveBuild();
    }


    #endregion
}
