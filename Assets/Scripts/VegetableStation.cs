using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableStation : MonoBehaviour
{
    CharacterBase TempChar;
    Vegetable myVegetable;
    private void Start()
    {
        myVegetable = GetComponentInChildren<Vegetable>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        TempChar = other.gameObject.GetComponent<CharacterBase>();
        TempChar.vegetableInFrontOfMe= myVegetable;
        TempChar.canPickUpVegetable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        TempChar.vegetableInFrontOfMe = null;
        TempChar.canPickUpVegetable = false;
        Debug.Log("out");
    }
}
