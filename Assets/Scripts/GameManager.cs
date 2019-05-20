using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject EndPanel;
    public Text endPanelScore;
    public Text endPanelWinner;
    public Text[] texts;
    public ChefComponent playerOne;
    public ChefComponent playerTwo;
    public GameObject pickupPrefab;
    public GameObject customerPrefab;
    public Transform[] CustomerSpawnPoints;
    public float delayBetweenCustomers;

    public Collider2D bounds;
    private void Start()
    {

        StartCoroutine(Spawner());
        StartCoroutine(updateScore());

    }
    public void MinusBothScores(int scoreToSubtract)
    {
        playerOne.score -= scoreToSubtract;
        playerTwo.score -= scoreToSubtract;
    }
    public void SpawnPickUp(int forWhomLayer10or11)
    {
        (Instantiate(pickupPrefab, RandomPointInKitchen(), Quaternion.identity)).layer = forWhomLayer10or11;
    }
    Vector3 RandomPointInKitchen()
    {
        Vector3 randomizedPoint;
        randomizedPoint.x = Random.Range(bounds.bounds.min.x, bounds.bounds.max.x);
        randomizedPoint.y = Random.Range(bounds.bounds.min.y, bounds.bounds.max.y);
        randomizedPoint.z = 0;
        return randomizedPoint;
    }
    IEnumerator updateScore()
    {

        texts[0].text = "Score: " + playerOne.score;
        texts[1].text = "Time: " + playerOne.timeRemaining;
        texts[2].text = "Score: " + playerTwo.score;
        texts[3].text = "Time: " + playerTwo.timeRemaining;

        yield return new WaitForSeconds(1);
        StartCoroutine(updateScore());
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(delayBetweenCustomers);
        for (int i = 0; i < CustomerSpawnPoints.Length; i++)
        {
            if (CustomerSpawnPoints[i].childCount == 0)
            {
                Instantiate(customerPrefab, CustomerSpawnPoints[i]).transform.localPosition = Vector3.zero;

            }
        }
        StartCoroutine(Spawner());
    }
    private void FixedUpdate()
    {
        if (playerOne.timeRemaining<1 && playerTwo.timeRemaining<1)
        {
            EndPanel.SetActive(true);
            if (playerOne.score>playerTwo.score)
            {
                endPanelWinner.text = playerOne.name;
                endPanelScore.text = playerOne.score.ToString();
            }
            else
            {
                endPanelWinner.text = playerTwo.name;
                endPanelScore.text = playerTwo.score.ToString();
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
