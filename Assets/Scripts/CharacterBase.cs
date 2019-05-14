using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    //Set Dynamically
    public float choppingTime;
    public float timeRemaining;
    public Vector3 childOffset;
    //-----------------------------
    protected Vegetable saladWithMe;
    [SerializeField]protected ChoppingBoard myBoard;
    internal float score;
    internal bool canChop;
    internal bool canPickUpVegetable;
    internal bool canPickUpSalad;
    internal bool hasSalad;
    internal Vegetable vegetableInFrontOfMe;
    internal List<Vegetable> Inventory = new List<Vegetable>();
    internal MovementComponent myMovement;
    private void Start()
    {
        myMovement = GetComponent<MovementComponent>();
    }


}
