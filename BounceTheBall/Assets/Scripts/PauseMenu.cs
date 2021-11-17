using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject quitPanel;

    void Start()
    {
        pausePanel.gameObject.SetActive(false);
        quitPanel.gameObject.SetActive(false);

    }
    public void PauseGame()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

    public void ResumeGame()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    public void QuitGame()
    {
        quitPanel.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
    }

    public void Yes()
    {
        
        SceneManager.LoadScene("Menu");

    }

    public void No()
    {
        quitPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
