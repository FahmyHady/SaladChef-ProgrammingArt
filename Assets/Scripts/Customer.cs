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
    void Start()
    {
        myRequest = GetComponentInChildren<Salad>();
        patienceBarSprite = GetComponentInChildren<Image>();
        allTypes = System.Enum.GetValues(myRequest.myType.GetType());
        for (int i = 1; i < allTypes.Length - 1; i++)
        {
            typesToChooseFrom.Add(allTypes.GetValue(i));
        }
        numberOfTypesInRequest = Random.Range(1, 7);
        SetComponentsType(numberOfTypesInRequest);
        myRequest.SetSaladComponents();
        SetPatienceAndScore();
        currentPatience = maxPatience;
        StartCoroutine(DepletePatience());
    }
    void SetComponentsType(int length)
    {
        for (int i = 0; i < length; i++)
        {

            temp = (VegetableType)typesToChooseFrom[Random.Range(0, typesToChooseFrom.Count)];
            typesToChooseFrom.Remove(temp);
            myRequest.myType = myRequest.myType | temp;

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
        currentPatience -= patienceDepletionRate;
        patienceBarSprite.fillAmount = currentPatience / maxPatience;
        if (currentPatience < 0.1)
        {
            //TODO minuses both players score
            //TODO if isAngry minuses who made him angry score
        }
        else
        {

            StartCoroutine(DepletePatience());
        }
    }
    public bool ReceiveSalad(Salad recievedSalad)
    {
        if (recievedSalad.myType == myRequest.myType)
        {
            //TODO increaseScore
            //TODO if 70% of time remaining spawnPickup
            return true;
        }
        else
        {
            //TODO angry
            //TODO Who made me angry
            return false;
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
