using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed;
    internal bool canMove;
    float vertical;
    float horizontal;
    CharacterBase mybase;
    protected Rigidbody2D mybody;
    void Start()
    {
        mybase = GetComponent<CharacterBase>();
        canMove = true;
        mybody = GetComponent<Rigidbody2D>();
    }
    void Movement()
    {
        vertical = Input.GetAxisRaw(mybase.myVAxis);
        horizontal = Input.GetAxisRaw(mybase.myHAxis);
        if (vertical==0)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, 0);
        }
        if (horizontal==0)
        {
            mybody.velocity = new Vector2(0, mybody.velocity.y);
        }
        if (Mathf.Abs(vertical)>0)
        {
            mybody.velocity = new Vector2(mybody.velocity.x, vertical*speed);
        }
       
        if (Mathf.Abs( horizontal)>0)
        {
            mybody.velocity = new Vector2(horizontal*speed, mybody.velocity.y);
        }
        
    }

    void Update()
    {
        if (canMove)
        {
            Movement();
        }
    }
}
