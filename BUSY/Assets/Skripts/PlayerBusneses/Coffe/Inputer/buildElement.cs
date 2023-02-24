using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildElement : MonoBehaviour
{
    [Header("Profit Stats")]
    public int countOfPeople;
    public int idOfStyle;
    public int countOfProduct;

    [Header("Element Stats")]
    [SerializeField] private Coffee master;
    [SerializeField] private CoffeEditor editor;
    [SerializeField] private CoffeeBuilding builder;

    public int InputerId;
    public int idOfBuilding;
    [SerializeField] private int id;
    [SerializeField] private int price;


    [SerializeField] private GameObject pannelAbout;

    [Header("for Colliders")]
    [SerializeField] private LayerMask isStandble;
    [SerializeField] private LayerMask isReboot;


    [SerializeField] private string nameOfInputer;

    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;

    private float x;

    private void Start()
    {

    }
    private void Update()
    {
        if (x < 1) x += Time.deltaTime;
        if (x > 1 && x < 10)
        {
            editor = GameObject.Find("CoffeeRedactor" + idOfBuilding.ToString()).GetComponent<CoffeEditor>();
            master = GameObject.Find("Coffee").GetComponent<Coffee>();
            builder = GameObject.Find("Build (Coffee)" + idOfBuilding.ToString()).GetComponent<CoffeeBuilding>();
            x = 100;
        }
        DestroyColliders();
    }
    private void DestroyColliders()
    {
        Collider2D[] detectedObjs = Physics2D.OverlapBoxAll(transform.position, new Vector2(scaleX, scaleY), 0, isStandble);

            foreach (Collider2D col in detectedObjs)
            {
                col.transform.SendMessage("ChangeValue", nameOfInputer);
            }

    }

    private void OnMouseDown()
    {
        pannelAbout.SetActive(true);
    }

    public void SellElement()
    {
        builder.destrElem(id, InputerId);

        master.productProfit[6] += price;
        master.productCounts[6]++;
        RebootColliders();

        Destroy(gameObject);
    }

    public void ReplaceElement()
    {
        builder.destrElem(id, InputerId);

        editor.newInputer(id);
        RebootColliders();

        Destroy(gameObject);
    }

    private void RebootColliders()
    {
        Collider2D[] detectedObjs = Physics2D.OverlapBoxAll(transform.position, new Vector2(scaleX, scaleY), 0, isReboot);

        foreach (Collider2D col in detectedObjs)
        {
            col.transform.SendMessage("Revert");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(scaleX, scaleY, 0f));
    }
}
