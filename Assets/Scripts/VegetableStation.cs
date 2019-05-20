using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableStation : MonoBehaviour
{
    CharacterBase tempChef;
    Vegetable myVegetable;
    private void Start()
    {
        myVegetable = GetComponentInChildren<Vegetable>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tempChef==null)
        {
        tempChef = collision.gameObject.GetComponent<CharacterBase>();
        tempChef.vegetableInFrontOfMe= myVegetable;
        tempChef.canPickUpVegetable = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tempChef.gameObject == collision.gameObject)
        {

            tempChef.vegetableInFrontOfMe = null;
            tempChef.canPickUpVegetable = false;
            tempChef = null;
        }
    }
}
