using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject hud;

    public GameObject menu;

    void Start()
    {

        Time.timeScale = 0;

    }

    public void StartGame()
    {
        menu.SetActive(false);

        Time.timeScale = 1;

        hud.SetActive(true);
    }

    public void QuitGame()
    {

        Application.Quit();

    }


}
