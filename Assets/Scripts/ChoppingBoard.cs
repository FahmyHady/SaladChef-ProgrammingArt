using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    VegetableType saladOnBoard = VegetableType.None;
    CharacterBase tempChar;
    int numberOfItemsInSalad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempChar = collision.GetComponent<CharacterBase>();
        if (numberOfItemsInSalad > 1)
        {
            tempChar.canPickUpSalad = true;
        }
        if (saladOnBoard != VegetableType.All && tempChar.Inventory.Count>0 && ((saladOnBoard & tempChar.Inventory[0].vegetableType) != tempChar.Inventory[0].vegetableType))
        {
            tempChar.canChop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tempChar.canPickUpSalad = false;
        tempChar.canChop = false;
    }
    public void AddToSalad(VegetableType vegetableToAdd)
    {
        if (saladOnBoard != VegetableType.All)
        {
            numberOfItemsInSalad += 1;
            saladOnBoard = saladOnBoard | vegetableToAdd;
            Debug.Log(saladOnBoard);
        }
    }
    public VegetableType GetSalad()
    {
        VegetableType saladToPlayer = saladOnBoard;
        saladOnBoard = VegetableType.None;
        numberOfItemsInSalad = 0;
        return saladToPlayer;
    }

}
