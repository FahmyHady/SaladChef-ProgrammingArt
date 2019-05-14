using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : CharacterBase
{

    void Movement()
    {


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            mybody.velocity = new Vector2(mybody.velocity.x, 0);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            mybody.velocity = new Vector2(0, mybody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            mybody.velocity = new Vector2(mybody.velocity.x, speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            mybody.velocity = new Vector2(mybody.velocity.x, -speed);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
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
