using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  private string nameLevel;
    [SerializeField]  private GameObject MainMenu;
    [SerializeField]  private GameObject OptionsMenu;

    public void Play()
    {
        SceneManager.LoadScene(nameLevel);
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

}
