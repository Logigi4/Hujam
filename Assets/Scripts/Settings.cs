using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public Animator anim;

    public void OpenCanvas()
    {
        anim.SetBool("Op", true);
    }
    public void CloseCanvas()
    {
        anim.SetBool("Op", false);
    }


}
