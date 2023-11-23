using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public GameObject ScoreText;
    public GameObject MultiplierText;
    public GameObject StartStuff;
    public GameObject StartMenuObject;
    public GameManager GM;

    public void StartGame()
    {
        ScoreText.SetActive(true);
        MultiplierText.SetActive(true);
        StartStuff.SetActive(true);
        GM.startPlaying = false;
        StartMenuObject.SetActive(false);
    }

}
