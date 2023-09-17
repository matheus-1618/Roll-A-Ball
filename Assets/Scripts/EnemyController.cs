using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
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

    public AudioSource touchSound;

    void Start()
    {
        mainSlider.maxValue = maxValue;
        mainSlider.value = maxValue;
        touchSound.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
        Debug.Log(enemy.speed);
    }
    IEnumerator ShowMessage(string message)
    {
        winTextObject.text = message;
        winTextObject1.SetActive(true);
        yield return new WaitForSeconds(3);
        winTextObject1.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            touchSound.Play();
            StartCoroutine(ShowMessage("Attacked!"));
            mainSlider.value -= minusValue;
            if  (mainSlider.value == dangerValue) {
                StartCoroutine(ShowMessage("DANGER!"));
            }
            if (mainSlider.value <= 0)
            {
                SceneManager.LoadScene("Scenes/Gameover");
            }
            enemy.speed += (float) 0.2;
        }
    }
}
