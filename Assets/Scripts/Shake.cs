using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShake()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            camAnim.SetTrigger("shake1");
        } else if (rand == 1)
        {
            camAnim.SetTrigger("shake2");
        } else if (rand == 2)
        {
            camAnim.SetTrigger("shake3");
        } else if (rand == 3)
        {
            camAnim.SetTrigger("shake4");
        } else if (rand == 4)
        {
            camAnim.SetTrigger("shake5");
        }
    }
}
