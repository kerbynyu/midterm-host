using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDelete : MonoBehaviour {
    private static dontDelete instance;

    private void Start() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);

        }else {
            Destroy(gameObject);

        }
    }
}
