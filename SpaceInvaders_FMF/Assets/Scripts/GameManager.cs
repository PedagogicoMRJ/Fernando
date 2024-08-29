using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    
    void Setup(){
        music.Play();
    }
}