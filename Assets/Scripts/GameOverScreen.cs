using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required when Using UI elements.

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private string nameLevel;
    // Start is called before the first frame update
    public void Play()
    {
        PlayerController.clock = 40;
        PlayerController.count = 0;
        SceneManager.LoadScene(nameLevel);
    }
}
