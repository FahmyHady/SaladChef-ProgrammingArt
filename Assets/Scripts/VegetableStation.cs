using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableStation : MonoBehaviour
{
    CharacterBase TempChar;
    Vegetable myVegetable;
    private void Start()
    {
        myVegetable = GetComponent<Vegetable>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        TempChar = other.GetComponent<CharacterBase>();
        TempChar.vegetableInFrontOfMe= myVegetable;
        TempChar.canPickUpVegetable = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        TempChar.vegetableInFrontOfMe = null;
        TempChar.canPickUpVegetable = false;
    }
}
