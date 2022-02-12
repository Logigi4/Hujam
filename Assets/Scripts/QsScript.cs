using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QsScript : MonoBehaviour
{

    public int QsNumber;

    public GameObject Cor;
    public GameObject Wron;
    public GameObject Wron2;

    private void Awake()
    {
        Cor.SetActive(false);
        Wron.SetActive(false);
        Wron2.SetActive(false);
    }

    public void CorrectAnswer()
    {
        
       GameMan.TrueQs[QsNumber] = true;
        Cor.SetActive(true);
        Wron.SetActive(false);
        Wron2.SetActive(false);

    }

    public void WrongAnswer()
    {

        GameMan.TrueQs[QsNumber] = false;
        Cor.SetActive(false);
        Wron.SetActive(true);
        Wron2.SetActive(false);

    }

    public void WrongAnswerTwo()
    {

        GameMan.TrueQs[QsNumber] = false;
        Cor.SetActive(false);
        Wron.SetActive(false);
        Wron2.SetActive(true);

    }

}
