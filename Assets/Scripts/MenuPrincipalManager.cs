using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required when Using UI elements.

public class MenuPrincipalManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  private string nameLevel;
    [SerializeField]  private GameObject MainMenu;
    [SerializeField]  private GameObject OptionsMenu;
    public TextMeshProUGUI speedValue;
    public Slider mainSlider;
    [SerializeField] public Button easy;
    [SerializeField] public Button medium;
    [SerializeField]public Button hard;

    public void Play()
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        float totalSpeed =  (10) * (mainSlider.value + 1);
        PlayerController.speed = (int) totalSpeed;
        Debug.Log(PlayerController.speed);
        speedValue.text = Convert.ToInt32(totalSpeed).ToString();
    }

    public void OpenOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void EasySelection()
    {
        ColorBlock cb = easy.colors;
        cb.normalColor = Color.blue;
        easy.colors = cb;
        EnemyController.maxValue = 10;
        EnemyController.minusValue = 1;
        EnemyController.dangerValue = 2;
    }
    public void MediumSelection()
    {
        ColorBlock cb = medium.colors;
        cb.normalColor = Color.blue;
        medium.colors = cb;
        EnemyController.maxValue = 15;
        EnemyController.minusValue = 3;
        EnemyController.dangerValue = 3;
    }
    public void HardSelection()
    {
        ColorBlock cb = hard.colors;
        cb.normalColor = Color.blue;
        hard.colors = cb;
        EnemyController.maxValue = 15;
        EnemyController.minusValue = 5;
        EnemyController.dangerValue = 5;
    }
}
