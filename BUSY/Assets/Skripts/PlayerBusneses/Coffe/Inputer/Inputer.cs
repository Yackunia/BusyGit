using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputer : MonoBehaviour
{
    private bool isStay;

    [SerializeField] private CoffeEditor master;
    [Header("Standing process")]
    [SerializeField] private bool isStanding;

    [SerializeField] private int posXcount;
    [SerializeField] private int posYcount;

    [SerializeField] private float distance = 1f;

    [SerializeField] private GameObject buildElem;

    [SerializeField] private Transform defPoint;

    [SerializeField] private LayerMask isStandble;

    [Header("Stats")]
    [SerializeField] private string nameOfInputer;

    [SerializeField] private int countOfPoints;



    [SerializeField] private int idOfInputer;
    private int idOfBuild;

    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;
    [SerializeField] private float price;

    private float posX;
    private float posY;
    private void Start()
    {
        isStay = false;
    }
    private void Update()
    {
        float x = 0;
        if (Input.GetKeyDown(KeyCode.R) && !isStay)
        {
            transform.Rotate(0.0f, 0.0f, 90.0f);
            x = scaleX;
            scaleX = scaleY;
            scaleY = x;
        }
    }
    
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
        transform.position = objPosition;

        CheckPlitkaHitBox();
    }
    private void OnMouseUp()
    {
        if (isStanding) StandTheObject();
        else transform.position = defPoint.position;
    }

    private void StandTheObject()
    {
        SetPlitkaValue();
        isStay = true;

        buildElement elem = Instantiate(buildElem, transform.position, transform.rotation,
            transform.parent).GetComponent<buildElement>();
        elem.InputerId = master.building.inp[idOfInputer].coordinate.Count;
        elem.idOfBuilding = master.building.idOfBuild;
        if(transform.rotation.z!=0) master.building.ChangeCoordinatesOfFurniture(idOfInputer, 
            transform.position.x, transform.position.y, 90f, elem);
        else master.building.ChangeCoordinatesOfFurniture(idOfInputer,
            transform.position.x, transform.position.y, 0f, elem);

        Destroy(gameObject);
    }

    private void CheckPlitkaHitBox()
    {
        Collider2D[] detectedObjs = Physics2D.OverlapBoxAll(transform.position, new Vector2(scaleX, scaleY), 0,isStandble);

  
        if (detectedObjs.Length == countOfPoints)
        {
            isStanding = true;
            foreach (Collider2D col in detectedObjs)
            {
                col.transform.SendMessage("GoodCount");
            }
        }
        else 
        {
            foreach (Collider2D col in detectedObjs)
            {
                col.transform.SendMessage("BadCount");
            }
            isStanding = false;
        }
    }

    private void SetPlitkaValue()
    {
        Collider2D[] detectedObjs = Physics2D.OverlapBoxAll(transform.position, new Vector2(scaleX, scaleY), 0, isStandble);
        posX = 0;
        posY = 0;
        if (detectedObjs.Length == countOfPoints)
        {
            foreach (Collider2D col in detectedObjs)
            {
                posX += col.transform.position.x;
                posY += col.transform.position.y;
                col.transform.SendMessage("ChangeValue", nameOfInputer);
            }
            posX /= countOfPoints;
            posY /= countOfPoints;

            transform.position = new Vector2(posX, posY);
        }
        
        else
            Debug.Log("InterestingError");
    }

    public void SetIdOfBuild(int id)
    {
        idOfBuild = id;
        master = GameObject.Find("CoffeeRedactor"+idOfBuild).GetComponent<CoffeEditor>();
        Debug.Log("i Found You");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(scaleX, scaleY, 0f));
    }

}
