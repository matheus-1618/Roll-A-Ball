using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform enemyBody;
    public TextMeshProUGUI winTextObject;
    public GameObject winTextObject1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            winTextObject.text = "You Lose!";
            winTextObject1.SetActive(true); 
        }
    }
}
