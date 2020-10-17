using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone2 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    public SmoothCamera2 smoothCameraScript;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            smoothCameraScript.inDeadZone = true;
            smoothCameraScript.inCamera = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            smoothCameraScript.inDeadZone = false;
            smoothCameraScript.inCamera = false;
        }
    }
}

