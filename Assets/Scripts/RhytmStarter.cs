using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RhytmStarter : MonoBehaviour
{

    public GameObject PressText;

    public AudioSource Music;

    public bool StartPlaying;

    public BeatScroller theBs;

    public static RhytmStarter RTS;

    public int CurrentScore;
    public int ScorePerNote = 100;
    public int ScorePerGoodNote = 150;
    public int ScoreperPerfectNote = 200;

    public int CurrentMultiplier;
    public int MultiplierTracker;
    public int[] multiplierThresholds;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI MultiText;


    void Start()
    {
        RTS = this;

        scoreText.text = "Score: " + 0;
        CurrentMultiplier = 1;

    }

    void Update()
    {
        if (!StartPlaying)
        {
            if (Input.anyKeyDown)
            {
                PressText.SetActive(false);
                StartPlaying = true;
                theBs.hasStarted = true;

                Music.Play();

            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        if (CurrentMultiplier - 1 < multiplierThresholds.Length)
        {
            MultiplierTracker++;

            if (multiplierThresholds[CurrentMultiplier - 1] <= MultiplierTracker)
            {
                MultiplierTracker = 0;
                CurrentMultiplier++;
            }
        }

        MultiText.text = CurrentMultiplier + "X";

       // CurrentScore += ScorePerNote * CurrentMultiplier;
       scoreText.text = "Score: " + CurrentScore;
    }

    public void NormalHit()
    {
        CurrentScore += ScorePerNote * CurrentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        CurrentScore += ScorePerGoodNote * CurrentMultiplier;
        NoteHit();
    }
    public void PerfectHit()
    {
        CurrentScore += ScoreperPerfectNote * CurrentMultiplier;
        NoteHit();
    }


    public void NoteMissed()
    {
        Debug.Log("Miss");
        CurrentMultiplier = 1;
        MultiplierTracker = 0;
        MultiText.text = CurrentMultiplier + "X";
    }


}
