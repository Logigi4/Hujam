using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{


    public GameObject RhythmGameAll;
    public GameObject RhythmCanvas;

    public float WaitTime;

    void Start()
    {
        RhythmGameAll.SetActive(false);
        RhythmCanvas.SetActive(false);
        StartCoroutine(WaitForMonke());
    }

    void Update()
    {
        
    }

    public IEnumerator WaitForMonke()
    {

        yield return new WaitForSeconds(WaitTime);

        RhythmGameAll.SetActive(true);
        RhythmCanvas.SetActive(true);

    }

}

