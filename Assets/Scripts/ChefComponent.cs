using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefComponent : CharacterBase
{
    void AddToInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (vegetableInFrontOfMe && Inventory.Count < 2)
            {
                Inventory.Add(Instantiate(vegetableInFrontOfMe,transform.position+childOffset,transform.rotation,transform));
            }

        }
    }
    void StartChop()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Inventory.Count > 0)
        {
            StartCoroutine(ChoppingInProgress(Inventory[0]));
        }
    }
    IEnumerator ChoppingInProgress(Vegetable vegetableToChop)
    {
        Inventory.Remove(vegetableToChop);
        canMove = false;
        canChop = false;
        yield return new WaitForSeconds(choppingTime);
        canMove = true;
        canChop = true;
        vegetableToChop.chopped = true;
    }
   
    void Update()
    {
        if (canPickUpVegetable)
        {
            AddToInventory();
        }
        if (canChop)
        {
            StartChop();
        }
    }
}
