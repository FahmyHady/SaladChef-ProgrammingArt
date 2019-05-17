using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    //Set Dynamically
    public float choppingTime;
    public float timeRemaining;
    //-----------------------------
    protected GameObject saladWithMe;
    protected Salad saladWithMeComponent;
    [SerializeField] protected ChoppingBoard myBoard;
    [SerializeField] protected Plate myPlate;
    internal float score;
    internal bool canChop;
    internal bool canPlaceOnPlate;
    internal bool canPickUpFromPlate;
    internal bool canPickUpVegetable;
    internal bool canPickUpSalad;
    internal bool hasSalad;
    internal bool canGiveSalad;
    internal bool canThrowSalad;
    internal Vegetable vegetableInFrontOfMe;
    internal Customer customerInFrontOfMe;
    internal List<Vegetable> Inventory = new List<Vegetable>();
    internal MovementComponent myMovement;
    internal GameObject item1;
    internal GameObject item2;
    internal GameObject saladPos;
    private void Start()
    {
        myMovement = GetComponent<MovementComponent>();
        item1 = transform.GetChild(0).gameObject;
        item2 = transform.GetChild(1).gameObject;
        saladPos = transform.GetChild(2).gameObject;
    }


}
