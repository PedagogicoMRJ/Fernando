using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    public int totalscore;

    public Text scoreboard;
    public GameObject gameover;
    public GameObject winner;

    public static GameManager access;

    void Start()
    {

        access = this;


    }


    public void ScoreBoard()
    {

        scoreboard.text = totalscore.ToString();

    }

    public void GameOver()
    {

        gameover.SetActive(true);

    }


    public void Restart()
    {

        SceneManager.LoadScene("SampleScene");

    }
    public void Winner()
    {

        winner.SetActive(true);

    }
}


