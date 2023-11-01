using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource Music;

    public bool startPlaying;
    bool onlyOnce = false;

    public BeatScroller BS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public TextMeshProUGUI percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    public GameObject keysDisplay;
    public GameObject songStartText;
    public TextMeshProUGUI songCountdownText;

    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if(!onlyOnce)
            {
                StartCoroutine(startingSong());
            }
        }
        else
        {
            if(!Music.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100;

                percentHitText.text = percentHit.ToString("F1") + "%"; // F1 means that it shows 1 decimal

                string rankVal = "";

                switch (percentHit)
                {
                    case >95:
                        rankVal = "S";
                        rankText.color = new Color32(195, 150, 0, 255);
                        break;
                    case >85:
                        rankVal = "A";
                        rankText.color = new Color32(0, 255, 0, 255);
                        break;
                    case >70:
                        rankVal = "B";
                        rankText.color = new Color32(0, 0, 255, 255);
                        break;
                    case >55:
                        rankVal = "C";
                        rankText.color = new Color32(255, 118, 0, 255);
                        break;
                    case >40:
                        rankVal = "D";
                        rankText.color = new Color32(135, 91, 63, 255);
                        break;
                    case <40:
                        rankVal = "F";
                        rankText.color = new Color32(255, 0, 0, 255);
                        break;
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
                finalScoreText.color = rankText.color;

            }
        }
    }

    public void NoteHit()
    {
        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMiss()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }

    IEnumerator startingSong()
    {
        onlyOnce = true;
        songCountdownText.text = "3";
        yield return new WaitForSeconds(1f);
        songCountdownText.text = "2";
        yield return new WaitForSeconds(1f);
        songCountdownText.text = "1";
        yield return new WaitForSeconds(1f);
        songStartText.SetActive(false);
        keysDisplay.SetActive(false);
        startPlaying = true;
        BS.hasStarted = true;

        Music.Play();
    }
}
