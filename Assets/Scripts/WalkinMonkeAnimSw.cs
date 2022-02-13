using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkinMonkeAnimSw : MonoBehaviour
{

    public Animator anim;


    public void GoToIdle()
    {
        anim.SetTrigger("Idle");
    }

    public void GoToDj()
    {
        anim.SetTrigger("Dj");
    }

}
