using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioSource Music;

    public bool startPlaying;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                BS.hasStarted = true;

                Music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        currentScore += scorePerNote;
    }

    public void NoteMiss()
    {
        Debug.Log("Missed Note");
    }
}
