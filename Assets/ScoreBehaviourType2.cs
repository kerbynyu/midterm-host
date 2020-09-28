using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBehaviourType2 : MonoBehaviour
{

    public scoreBehaviour sc;

    
    void Start()
    {
        gameObject.SetActive(false);
    }
    /*
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.name.Equals("Player")) {
            
        }
    }
    */

    void udate(){
        if(sc.collected == true) {
            gameObject.SetActive(true);
        }
    }
}
