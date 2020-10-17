using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreBehaviour : MonoBehaviour{
    public bool collected = false;
    public GameMaster gm;

    private void Awake() {
     
    }

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameMaster>();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            SoundManagerScript.playSound("collect");
            this.gameObject.SetActive(false);
            collected = true;
            addScore();
        }
    }

    public void OnTriggerStay2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player")) {
            SoundManagerScript.playSound("collect");
            this.gameObject.SetActive(false);
            collected = true;
            addScore();
        }        
    }

    public void addScore() {
        gm.score++;
    }
}
