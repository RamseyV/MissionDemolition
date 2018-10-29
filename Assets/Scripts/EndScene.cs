using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {
    public int highScore;
    public int score;
    public Text hsText;
    public Text scoreText;


	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
            score = 0;
        }

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else{
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }




		
	}
	
	// Update is called once per frame
    void Update (){
        hsText.text = "High Score: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();

		
	}
}
