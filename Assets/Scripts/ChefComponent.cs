using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefComponent : CharacterBase
{

    void PickSaladUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            saladWithMe.vegetableType = myBoard.GetSalad();
            Instantiate(saladWithMe, transform.position + childOffset, transform.rotation, transform);
            hasSalad = true;
        }
    }
    void AddToInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (vegetableInFrontOfMe && Inventory.Count < 2)
            {
                Inventory.Add(Instantiate(vegetableInFrontOfMe, transform.position + childOffset, transform.rotation, transform));
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
        myMovement.canMove = false;
        canChop = false;
        yield return new WaitForSeconds(choppingTime);
        myBoard.AddToSalad(vegetableToChop.vegetableType);
        Destroy(vegetableToChop.gameObject);
        myMovement.canMove = true;
        canChop = true;

    }

    void Update()
    {
        if (canPickUpVegetable)
        {
            AddToInventory();
        }
        if (canChop)
        {
            Debug.Log(canChop);
            StartChop();
        }
        if (canPickUpSalad)
        {
            PickSaladUp();
        }
        Debug.Log(canPickUpVegetable);
    }
}
