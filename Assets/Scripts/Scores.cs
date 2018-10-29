using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    public static int score = 0;
    public int hs;
    public Text hsText;
    public Text scoreText;

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        hs = PlayerPrefs.GetInt("HighScore");
        score = 0;
        PlayerPrefs.SetInt("Score", score);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hs = PlayerPrefs.GetInt("HighScore");
        hsText.text = "High Score: " + hs.ToString();

        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
