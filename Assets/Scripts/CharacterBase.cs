using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    //Set Dynamically
    public float choppingTime;
    public float timeRemaining;
    public int throwSaladPenatly;
    [SerializeField] [Range(1, 2)] int controlID;

    //-----------------------------
    internal string myHAxis;
    internal string myVAxis;
    internal string myInteractAxis;
    internal string myChopAxis;
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
    bool m_isAxisInUse = false;

    private void Start()
    {
        switch (controlID)
        {
            case 1:
                myHAxis = "PlayerOneH";
                myVAxis = "PlayerOneV";
                myInteractAxis = "PlayerOneInteract";
                myChopAxis = "PlayerOneChop";
                break;
            case 2:
                myHAxis = "PlayerTwoH";
                myVAxis = "PlayerTwoV";
                myInteractAxis = "PlayerTwoInteract";
                myChopAxis = "PlayerTwoChop";
                break;
        }
        myMovement = GetComponent<MovementComponent>();
        item1 = transform.GetChild(0).gameObject;
        item2 = transform.GetChild(1).gameObject;
        saladPos = transform.GetChild(2).gameObject;
        StartCoroutine(DepleteTime());
    }
    public bool getAxisDown(string whichAxis)
    {
        

        if (Input.GetAxisRaw(whichAxis) != 0)
        {
            if (m_isAxisInUse == false)
            {
                m_isAxisInUse = true;
                return m_isAxisInUse;
            }
        }
        if (Input.GetAxisRaw(whichAxis) == 0)
        {
            m_isAxisInUse = false;
            return m_isAxisInUse;
        }
        return false;
    }

    IEnumerator DepleteTime()
    {
        yield return new WaitForSeconds(1);

        timeRemaining -= 1;
        if (timeRemaining < 0.1)
        {
            myMovement.canMove = false;
        }
        else
        {

            StartCoroutine(DepleteTime());
        }
    }
}
