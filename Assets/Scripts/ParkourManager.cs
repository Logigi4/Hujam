using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParkourManager : MonoBehaviour
{

    public float timeValue = 90;
    public TextMeshProUGUI timeText;

    void Update()
    {

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            DisplayTime(Mathf.RoundToInt(timeValue));
        }
        else
        {
            timeValue = 0;
            timeText.text ="Oops, You are a little late. But you still gotta finish tho.";
        }

        



    }

    void DisplayTime(int TimeToDisplay)
    {
        timeText.text = TimeToDisplay.ToString() + " Seconds To Deadline";
    }




}
