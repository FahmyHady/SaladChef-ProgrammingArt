using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Customer : MonoBehaviour
{
    bool isAngry;
    float maxPatience;
    public float currentPatience;
    public float patienceDepletionRate;
    public int scoreIGive;
    public float extraTimePerComponent;
    public int extraScorePerComponent;
    int numberOfTypesInRequest;
    VegetableType temp;
    System.Array allTypes;
    List<object> typesToChooseFrom = new List<object>();
    Salad myRequest;
    Image patienceBarSprite;
    CharacterBase tempChef;
    List<CharacterBase> whoMadeMeAngry = new List<CharacterBase>();
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        myRequest = GetComponentInChildren<Salad>();
        patienceBarSprite = GetComponentInChildren<Image>();
        allTypes = System.Enum.GetValues(myRequest.myType.GetType());
        for (int i = 1; i < allTypes.Length - 1; i++)
        {
            typesToChooseFrom.Add(allTypes.GetValue(i));
        }
        numberOfTypesInRequest = Random.Range(1, 7);
        SetComponentsType();
        myRequest.SetSaladComponents();
        SetPatienceAndScore();
        currentPatience = maxPatience;
        StartCoroutine(DepletePatience());
    }
    void SetComponentsType()
    {
        for (int i = 0; i < numberOfTypesInRequest; i++)
        {

            temp = (VegetableType)typesToChooseFrom[Random.Range(0, typesToChooseFrom.Count)];
            myRequest.myType = myRequest.myType | temp;

            typesToChooseFrom.Remove(temp);

        }
    }

    void SetPatienceAndScore()
    {
        maxPatience += extraTimePerComponent * numberOfTypesInRequest;
        scoreIGive += extraScorePerComponent * numberOfTypesInRequest;
    }
    IEnumerator DepletePatience()
    {
        yield return new WaitForSeconds(1);
        if (isAngry)
        {
            currentPatience -= 1.5f * patienceDepletionRate;
            patienceBarSprite.color = Color.red;
        }
        else
        {
            currentPatience -= patienceDepletionRate;

        }
        patienceBarSprite.fillAmount = currentPatience / maxPatience;
        if (currentPatience < 0.1)
        {
            if (isAngry)
            {
                for (int i = 0; i < whoMadeMeAngry.Count; i++)
                {
                    whoMadeMeAngry[i].score -= scoreIGive * 2;
                }
            }
            else
            {
                gameManager.MinusBothScores(scoreIGive);
            }
            Destroy(gameObject);
        }
        else
        {

            StartCoroutine(DepletePatience());
        }
    }
    public void ReceiveSalad(Salad recievedSalad)
    {
        if (recievedSalad.myType == myRequest.myType)
        {
            tempChef.score += scoreIGive;

            if (currentPatience / maxPatience > 0.7f)
            {
                gameManager.SpawnPickUp(tempChef.gameObject.layer);
            }

            Destroy(gameObject);

        }
        else
        {
            isAngry = true;
            whoMadeMeAngry.Add(tempChef);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tempChef == null)
        {
            tempChef = collision.GetComponent<CharacterBase>();
            tempChef.canGiveSalad = true;
            tempChef.customerInFrontOfMe = this;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == tempChef.gameObject)
        {
            tempChef.canGiveSalad = false;
            tempChef.customerInFrontOfMe = null;
            tempChef = null;

        }

    }
}
