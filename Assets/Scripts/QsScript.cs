using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QsScript : MonoBehaviour
{

    public int QsNumber;


    public void CorrectAnswer()
    {
        
       GameMan.TrueQs[QsNumber] = true;

    }

    public void WrongAnswer()
    {

        GameMan.TrueQs[QsNumber] = false;

    }

}
