using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    Salad saladOnBoard;
    CharacterBase tempChef;
    int numberOfItemsInSalad;
    private void Start()
    {
        saladOnBoard = GetComponentInChildren<Salad>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tempChef == null)
        {

            tempChef = collision.GetComponent<CharacterBase>();
            if (numberOfItemsInSalad > 0 && tempChef.Inventory.Count == 0)
            {
                tempChef.canPickUpSalad = true;
            }
            if (saladOnBoard.myType != VegetableType.All && tempChef.Inventory.Count > 0)
            {
                tempChef.canChop = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == tempChef.gameObject)
        {

            tempChef.canPickUpSalad = false;
            tempChef.canChop = false;
            tempChef = null;

        }
    }
    public void AddToSalad(VegetableType vegetableToAdd)
    {
        if (saladOnBoard.myType != VegetableType.All && (saladOnBoard.myType & vegetableToAdd) != vegetableToAdd)
        {
            numberOfItemsInSalad += 1;
            saladOnBoard.myType = saladOnBoard.myType | vegetableToAdd;
            saladOnBoard.SetSaladComponents();
        }
    }
    public GameObject GetSalad()
    {
        GameObject saladToPlayer = Instantiate(saladOnBoard.gameObject, saladOnBoard.transform.position, saladOnBoard.transform.rotation);
        saladOnBoard.myType = VegetableType.None;
        saladOnBoard.SetSaladComponents();
        numberOfItemsInSalad = 0;
        return saladToPlayer;
    }

}
