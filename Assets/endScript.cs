using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
  
    public Sprite happy;
    public Sprite meh;
    public Sprite sad;
    public Sprite neutral;

    //public int score = 0;
    private GameMaster gm;

    public void Start() {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameMaster>();
        this.GetComponent<SpriteRenderer>().sprite = neutral;
    }

    public void OnTriggernEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (gm.score > 20) {
                this.GetComponent<SpriteRenderer>().sprite = happy;

            }else if (gm.score > 10) {
                this.GetComponent<SpriteRenderer>().sprite = meh;

            }else {
                this.GetComponent<SpriteRenderer>().sprite = sad;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (gm.score > 20) {
                this.GetComponent<SpriteRenderer>().sprite = happy;

            }else if (gm.score > 10) {
                this.GetComponent<SpriteRenderer>().sprite = meh;

            } else {
                this.GetComponent<SpriteRenderer>().sprite = sad;

            }
        }

    }
}
