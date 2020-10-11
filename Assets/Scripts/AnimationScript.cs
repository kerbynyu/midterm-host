using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    public Animator myAnimator;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            myAnimator.SetTrigger("change"); //parameter name in the animator
        }
    }
}
