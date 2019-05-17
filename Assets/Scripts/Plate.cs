using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    CharacterBase tempChef;
    internal int vegesOnPlate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tempChef ==null)
        {
            tempChef = collision.gameObject.GetComponent<CharacterBase>();
            if (vegesOnPlate < 1 && tempChef.Inventory.Count > 0)
            {
                tempChef.canPlaceOnPlate = true;
            }
            if (vegesOnPlate > 0)
            {
                tempChef.canPickUpFromPlate = true;
            }
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tempChef.gameObject==collision.gameObject)
        {
            tempChef.canPlaceOnPlate = false;
            tempChef.canPickUpFromPlate = false;
        }
    
    }
}
