using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public bool[] TrueQs;

    public void Awake()
    {
        TrueQs = new bool[] { false,false,false,false,false };
    }
    private void Update()
    {
        Debug.Log(TrueQs[0]);
    }

}
