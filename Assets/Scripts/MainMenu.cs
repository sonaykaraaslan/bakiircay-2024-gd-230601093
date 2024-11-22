using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject StartMenu;
    public GameObject GameOver;


    public void StartGame()
    {
        StartMenu.SetActive(false);
        GameManager.InitalizeScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameOver.SetActive(false);//GameOver nesnesi
        GameManager.InitalizeScene();
    }

}
