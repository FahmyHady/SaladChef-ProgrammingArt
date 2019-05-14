using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    //Set Dynamically
    public float speed;
    public float choppingTime;
    public float timeRemaining;
    public Vector3 childOffset;
    //-----------------------------
    protected Rigidbody2D mybody;
 [SerializeField]protected ChoppingBoard myBoard;
    internal float score;
    internal bool canMove;
    internal bool canChop;
    internal bool canPickUpVegetable;
    internal bool canPickUpSalad;
    internal bool hasSalad;
    internal Vegetable vegetableInFrontOfMe;
    internal List<Vegetable> Inventory = new List<Vegetable>();

    void Start()
    {
        canMove = true;
        mybody = GetComponent<Rigidbody2D>();
    }


}
