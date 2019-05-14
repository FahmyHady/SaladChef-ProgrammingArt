using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    VegetableType salad = VegetableType.None;
    CharacterBase tempChar;
    int numberOfItemsInSalad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempChar = collision.GetComponent<CharacterBase>();
        if (numberOfItemsInSalad>1)
        {
            tempChar.canPickUpSalad = true;
        }
        if (salad != VegetableType.All && ( (salad & tempChar.Inventory[0].vegetableType) != tempChar.Inventory[0].vegetableType ))
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
        if (salad != VegetableType.All)
        {
            numberOfItemsInSalad += 1;
            salad = salad | vegetableToAdd;
        }
    }
    public VegetableType GetSalad()
    {
        VegetableType saladToPlayer = salad;
        salad = VegetableType.None;
        numberOfItemsInSalad = 0;
        return saladToPlayer;
    }
    
}
