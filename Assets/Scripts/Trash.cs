using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    CharacterBase tempChef;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tempChef == null)
        {
            tempChef = collision.gameObject.GetComponent<CharacterBase>();
            tempChef.canThrowSalad = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tempChef?.gameObject == collision.gameObject)
        {
            tempChef.canThrowSalad = false;
            tempChef = null;

        }
    }
}
