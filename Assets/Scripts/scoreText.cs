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
        scoreCounter= GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameMaster>().score;
        ScoreText.text = scoreCounter.ToString();  // make it a string to output to the Text object
    }
}
