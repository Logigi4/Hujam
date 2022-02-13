using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonThreeD : MonoBehaviour
{

    public KeyCode keyToPress;

    [HideInInspector]
    public Vector3 StartScale;
    [HideInInspector]
    public Vector3 PressedScale;

    private void Start()
    {
        StartScale = transform.localScale;
        PressedScale = transform.localScale * 0.8f;
    }

    void Update()
    {

        if (Input.GetKey(keyToPress))
        {
            transform.localScale = PressedScale;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            transform.localScale = StartScale;
        }

    }
}
