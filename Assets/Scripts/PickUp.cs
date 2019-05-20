using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    PickUps mytype;
    SpriteRenderer spriteRenderer;
    public PickUpSO pickUpsSO;
    public int whoCanPickMeUp;
    CharacterBase tempChef;
    public float speedMultiplier;
    public int timeBoost;
    public int scoreBoost;
    int randomType;
    void Start()
    {
        randomType = Random.Range(0, 3);
        mytype = (PickUps)randomType;
        gameObject.layer = whoCanPickMeUp;
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (mytype)
        {
            case PickUps.Speed:
                spriteRenderer.sprite = pickUpsSO.Speed;
                break;
            case PickUps.Time:
                spriteRenderer.sprite = pickUpsSO.Time;
                break;
            case PickUps.Score:
                spriteRenderer.sprite = pickUpsSO.Score;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempChef = collision.gameObject.GetComponent<CharacterBase>();
        switch (mytype)
        {
            case PickUps.Speed:
                tempChef.myMovement.speed *= speedMultiplier;
                break;
            case PickUps.Time:
                tempChef.timeRemaining += timeBoost;
                break;
            case PickUps.Score:
                tempChef.score += scoreBoost;
                break;
        }
        Destroy(gameObject);
    }

}
enum PickUps
{
    Speed, Time, Score
}