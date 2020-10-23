using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whaleCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        SoundManagerScript.playSound("jump");
    }

    private void OnCollisionStay2D(Collision2D collision) {
        SoundManagerScript.playSound("jump");
    }
}
