using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject shopPanel;
    public GameObject scorePanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("BaseLevel");

    }

    public void GoToShop()
    {
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
        

    }

    public void BackToMenu()
    {
        mainMenuPanel.SetActive(true);
        shopPanel.SetActive(false);
        scorePanel.SetActive(false);



    }

    public void GoToScores()
    {
        mainMenuPanel.SetActive(false);
        scorePanel.SetActive(true);

    }
}
