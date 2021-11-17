using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gamePanel;

    public static bool isGameStarted;
    public bool isCoinEarned;
    public bool ishiScoreSent;
        
    public GameObject startingText;
    public static int numberOfCoins;
    public Text coinsText;
    public Text gameOverCoinsText;


    public GameObject[] buttons;

    void Start()
    {
        foreach(GameObject obj in buttons)
        {
            obj.SetActive(true);
        }
        
        
        gamePanel.SetActive(true);        
        gameOver = false;
        isCoinEarned = false;
        ishiScoreSent = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        if (gameOver)
            HighScoreUpdate();
    }

    
    void Update()
    {
        if (SwipeManager.tap)
        {
            isGameStarted = true;
            
            Destroy(startingText);

            foreach (GameObject obj in buttons)
            {
                obj.SetActive(true);
            }

        }
        if (gameOver)
        {
            if (!isCoinEarned)
            {
                PlayerPrefs.SetInt("NumberOfCurrency", Currency.coins += PlayerManager.numberOfCoins);
                isCoinEarned = true;
            }
           
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
        }
        

        coinsText.text =  "" + numberOfCoins;
        gameOverCoinsText.text = "" + numberOfCoins;
       
        


    }

    
    public void HighScoreUpdate()
    {
        DreamloScoreTable.AddNewHighscore(UserRegister.inputName.text, (int)ScoreManager.hiScoreCount);

    }
}
