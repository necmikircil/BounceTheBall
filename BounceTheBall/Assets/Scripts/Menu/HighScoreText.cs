using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    public Text yourHighScore;

    void Start()
    {
        
    }

    
    void Update()
    {
        yourHighScore.text = "Score: " + (int)PlayerPrefs.GetFloat("HighScore", ScoreManager.hiScoreCount);
    }
}
