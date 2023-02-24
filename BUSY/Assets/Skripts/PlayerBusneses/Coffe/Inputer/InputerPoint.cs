using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputerPoint : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private SpriteRenderer rend;
    public string valueOfPoint = "nothing";

    
    public void OnTriggerExit2D(Collider2D other)
    {
        rend.gameObject.SetActive(false);
    }
    private void BadCount()
    {
        rend.gameObject.SetActive(true);
        rend.color = Color.gray;
    }
    private void GoodCount()
    {
        rend.gameObject.SetActive(true);
        rend.color = Color.white;
    }

    private void ChangeValue(string newValue)
    {
        valueOfPoint = newValue;
        gameObject.layer = 0;
        rend.gameObject.SetActive(false);
    }
    private void Revert()
    {
        valueOfPoint = "nothing";
        gameObject.layer = id;

        Debug.Log("Yes");
    }
}
