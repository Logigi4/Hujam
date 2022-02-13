using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScrpit : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject Hit, Good, Perfect, Miss;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {

                //RhytmStarter.RTS.NoteHit();

                if (transform.position.y > 2.3f || transform.position.y < 1.7f)
                {
                    Debug.Log("Normal");
                    RhytmStarter.RTS.NoteHit();
                    Instantiate(Hit, transform.position, Hit.transform.rotation);
                }
                else if (transform.position.y > 2.15f || transform.position.y < 1.85f)
                {
                    Debug.Log("Good");
                    RhytmStarter.RTS.GoodHit();
                    Instantiate(Good, transform.position, Good.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    RhytmStarter.RTS.PerfectHit();
                    Instantiate(Perfect, transform.position, Perfect.transform.rotation);

                }

                gameObject.SetActive(false);
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Activator"))
        {
            RhytmStarter.RTS.NoteMissed();
            Instantiate(Miss, transform.position, Miss.transform.rotation);
            canBePressed = false;
        }
    }

}
