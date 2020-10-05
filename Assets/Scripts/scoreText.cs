using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour{
    public Text ScoreText;
    int scoreCounter;

    private void Start() {
        ScoreText = GetComponent<Text>();
       
    }

    void Update() {
        scoreCounter = GameObject.Find("Player").GetComponent<SimplePhysicsController>().score;
        ScoreText.text = scoreCounter.ToString();  // make it a string to output to the Text object
    }
}
