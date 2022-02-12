using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public bool[] TrueQs;

    public int Score;

    public bool AbleToWin;

    public void Awake()
    {
        TrueQs = new bool[] { false,false,false,false,false };
    }
    private void Update()
    {

        if (TrueQs[0] && TrueQs[1] && TrueQs[2] && TrueQs[3] && TrueQs[4])
        {
            AbleToWin = true;
        }
        else
        {
            AbleToWin = false;
        }



    }



}
