using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Diagnostics;
using System;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static public float speed = 10;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI clockText;

    private Rigidbody rb;
    private float movementX, movementY;
    public static int count;
    public static float clock = 40;
    

    public NavMeshAgent enemy1;
    public NavMeshAgent enemy2;
    private float clockFixed;

    public static float levelFactor = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        clockFixed = clock;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "RINGS: " + count.ToString() + "/12";
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            SceneManager.LoadScene("Scenes/WinGame");

        }
    }
    void Update()
    {
        if (clock > 0)
        {
            clock -= Time.deltaTime;
            clockText.text = Convert.ToInt32(clock).ToString();
        }
        else
        {
            SceneManager.LoadScene("Scenes/Gameover");
        }

        if (clock < clockFixed && clock > clockFixed * 3/4)
        {
            clockText.color = Color.green;
            enemy1.speed += (float)0.1 * Time.deltaTime * levelFactor;
            enemy2.speed += (float)0.1 * Time.deltaTime * levelFactor;
            enemy1.acceleration += (float)0.1 * Time.deltaTime * levelFactor;
            enemy2.acceleration += (float)0.1 * Time.deltaTime * levelFactor;
        }

        if (clock < clockFixed / 2 && clock > clockFixed / 4)
        {
            clockText.color = Color.yellow;
            enemy1.speed += (float)0.2 * Time.deltaTime * levelFactor;
            enemy2.speed += (float)0.2 * Time.deltaTime * levelFactor;
            enemy1.acceleration += (float)0.2 * Time.deltaTime * levelFactor;
            enemy2.acceleration += (float)0.2 * Time.deltaTime * levelFactor;
        }
        if (clock < clockFixed / 4 && clock > 0)
        {
            clockText.color = Color.red;
            enemy1.speed += (float)0.5 * Time.deltaTime * levelFactor;
            enemy2.speed += (float)0.5 * Time.deltaTime * levelFactor;
            enemy1.acceleration += (float)0.5 * Time.deltaTime * levelFactor;
            enemy2.acceleration += (float)0.5 * Time.deltaTime * levelFactor;
        }
    }
    private void FixedUpdate()
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        
    }

}
