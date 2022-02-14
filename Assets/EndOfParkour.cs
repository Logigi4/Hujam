using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfParkour : MonoBehaviour
{

    public SceneMaster Sm;

    public ParkourManager pk;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pk.timeValue > 0)
            {
                ScoreCounter.QuizzNumber += 1;
                ScoreCounter.Quizez[1] = true;
                EndOfQuizz();
            }
            else
            {
                EndOfQuizz();
            }
            
        }
    }

    public void EndOfQuizz()
    {
        Sm.LoadNextScene();
    }


}
