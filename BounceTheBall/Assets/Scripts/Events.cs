using UnityEngine;
using UnityEngine.SceneManagement;


public class Events : MonoBehaviour
{
    

    public void ReplayGame()
    {
        SceneManager.LoadScene("BaseLevel");



    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");


    }




}
