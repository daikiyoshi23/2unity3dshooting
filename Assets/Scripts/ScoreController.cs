﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

    public Text scoreText;
    public Text HighScore;
    int score;

	// Use this for initialization
	void Start () {
        score = 0;

        if(SceneManager.GetActiveScene().name == "Title")
        {
            HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Main")
        {
            scoreText.text = "Score: " + score;
        }
	}
    public void ScorePlus()
    {
        score += 10;
    }

    public void SaveHighScore()
    {
        if(PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        Invoke("ReturnTitle", 2.0f);
    }

    void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
