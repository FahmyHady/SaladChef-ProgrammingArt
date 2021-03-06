﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefComponent : CharacterBase
{
    void AddItem(Vegetable toInstantiate)
    {
        if (item1.transform.childCount == 0)
        {
            Inventory.Add(Instantiate(toInstantiate, item1.transform));
            Inventory[0].transform.localPosition = Vector3.zero;
            Inventory[0].transform.localScale = Vector3.one;
        }
        else
        {
            Inventory.Add(Instantiate(toInstantiate, item2.transform));
            Inventory[1].transform.localPosition = Vector3.zero;
            Inventory[1].transform.localScale = Vector3.one;
        }
    }
    void AddSalad(GameObject toInstantiate)
    {

        saladWithMe = Instantiate(toInstantiate, saladPos.transform);
        saladWithMe.transform.localPosition = Vector3.zero;
        saladWithMe.transform.localScale = Vector3.one;
    }
    void PickSaladUp()
    {
        if (getAxisDown(myInteractAxis))
        {
            saladWithMe = myBoard.GetSalad();
            AddSalad(saladWithMe);
            saladWithMeComponent = saladWithMe.GetComponent<Salad>();
            hasSalad = true;
        }
    }
    void AddToInventory()
    {
        if (getAxisDown(myInteractAxis))
        {
            if (vegetableInFrontOfMe && Inventory.Count < 2)
            {
                AddItem(vegetableInFrontOfMe);
            }

        }
    }
    void StartChop()
    {
        if (getAxisDown(myChopAxis) && Inventory.Count > 0)
        {

            StartCoroutine(ChoppingInProgress(Inventory[0].GetComponent<Vegetable>()));
        }
    }
    IEnumerator ChoppingInProgress(Vegetable vegetableToChop)
    {
        myMovement.canMove = false;
        canChop = false;
        yield return new WaitForSeconds(choppingTime);
        myBoard.AddToSalad(vegetableToChop.vegetableType);
        Inventory.Remove(vegetableToChop);
        Destroy(vegetableToChop.gameObject);
        myMovement.canMove = true;
        canChop = true;

    }
    void PlaceOneVegOnPlate()
    {
        if (getAxisDown(myInteractAxis) && Inventory.Count > 0 && myPlate.vegesOnPlate < 1)
        {
            myPlate.vegesOnPlate += 1;
            Inventory[0].transform.parent = myPlate.transform;
            Inventory[0].transform.localPosition = Vector3.zero;

            Inventory.RemoveAt(0);
        }
    }
    void PickUpFromPlate()
    {
        if (getAxisDown(myInteractAxis) && Inventory.Count < 2 && myPlate.vegesOnPlate > 0)
        {
            Transform temp = myPlate.transform.GetChild(0).transform;
            temp.parent = item2.transform;
            temp.localPosition = Vector3.zero;
            temp.localScale = Vector3.one;
            Inventory.Add(temp.GetComponent<Vegetable>());
            myPlate.vegesOnPlate -= 1;
            canPickUpFromPlate = false;
        }
    }
    void GiveSalad()
    {
        if (getAxisDown(myInteractAxis))
        {
            customerInFrontOfMe.ReceiveSalad(saladWithMeComponent);
            Destroy(saladWithMe);
            hasSalad = false;
        }
    }
    private void ThrowSaladInTrash()
    {
        if (getAxisDown(myInteractAxis))
        {
            Destroy(saladWithMe.gameObject);
            score -= throwSaladPenatly;
            hasSalad = false;
        }
    }
    void Update()
    {
        if (canPickUpVegetable && !hasSalad)
        {
            AddToInventory();
        }
        if (canChop)
        {
            StartChop();
        }
        if (canPickUpSalad && !hasSalad)
        {
            PickSaladUp();
        }
        if (canPlaceOnPlate)
        {
            PlaceOneVegOnPlate();
        }
        if (canPickUpFromPlate && !hasSalad)
        {
            PickUpFromPlate();
        }
        if (hasSalad && canGiveSalad)
        {
            GiveSalad();
        }
        if (canThrowSalad && hasSalad)
        {
            ThrowSaladInTrash();
        }
        if (item2.transform.childCount == 1 && item1.transform.childCount == 0)
        {
            item2.transform.GetChild(0).parent = item1.transform;
            item1.transform.GetChild(0).localPosition = Vector3.zero;
        }
    }

    
}
