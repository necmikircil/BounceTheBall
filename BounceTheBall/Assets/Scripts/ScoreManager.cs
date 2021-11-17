using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text lastScoreText;

    public static float scoreCount;
    public static float hiScoreCount;
    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start()
    {
        scoreCount = 0;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");

        }
    }

    
    void Update()
    {
        if(PlayerManager.isGameStarted == true)
        {
            scoreIncreasing = true;
            scoreCount += pointsPerSecond * Time.deltaTime * 10;

        }
           

        if (scoreCount > hiScoreCount && PlayerManager.gameOver)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
            
        }
            


        scoreText.text = "" + (int)(scoreCount);
        hiScoreText.text = "High Score: " + (int)(hiScoreCount);
        lastScoreText.text = "Last Score: " + (int)(scoreCount);


    }
}
