using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI; // Required when Using UI elements.
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform enemyBody;
    public TextMeshProUGUI winTextObject;
    public GameObject winTextObject1;
    public Slider mainSlider;

    public static int maxValue = 20;
    public static int minusValue = 5;
    public static int dangerValue = 5;

    void Start()
    {
        mainSlider.maxValue = maxValue;
        mainSlider.value = maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }
    IEnumerator ShowMessage()
    {
        winTextObject.text = "You are about to loose!";
        winTextObject1.SetActive(true);
        yield return new WaitForSeconds(3);
        winTextObject1.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            mainSlider.value -= minusValue;
            if  (mainSlider.value == dangerValue) {
                StartCoroutine(ShowMessage());
            }
            if (mainSlider.value <= 0)
            {
                winTextObject.text = "You Lose!";
                winTextObject1.SetActive(true); 
            }
            enemy.speed += 1;
        }
    }
}
