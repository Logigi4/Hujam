using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QsScript : MonoBehaviour
{

    public int QsNumber;


    public void CorrectAnswer()
    {
        
       GameManager.TrueQs[QsNumber] = true;

    }

    public void WrongAnswer()
    {

        GameManager.TrueQs[QsNumber] = false;

    }

}
