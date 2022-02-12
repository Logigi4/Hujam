using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkourManager : MonoBehaviour
{

    public float timeValue = 90;
    public Text timeText;

    void Update()
    {

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

    }

    void DisplayTime(float TimeToDisplay)
    {
        timeText.text = TimeToDisplay.ToString();
    }




}
