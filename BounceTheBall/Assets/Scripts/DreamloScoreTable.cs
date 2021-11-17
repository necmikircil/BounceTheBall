using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DreamloScoreTable : MonoBehaviour
{
    const string privateCode = "g-EirfbPT0a_Wiw_CiUpvw82y3GpIJgECNzByeOzydyA";
    const string publicCode = "61780e408f40bba8b4f9fd0f";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayHighScores highscoresDisplay;
    static DreamloScoreTable instance;

    private void Awake()
    {
        highscoresDisplay = GetComponent<DisplayHighScores>();
        instance = this;
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
#pragma warning restore CS0618 // Type or member is obsolete
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            
            DownloadHighScores();
        }
            
        
        else
            print("Error uploading: " + www.error);
    }
    
    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    
    
    IEnumerator DownloadHighscoresFromDatabase()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
#pragma warning restore CS0618 // Type or member is obsolete
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
            print("Error downloading: " + www.error);
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ":" + highscoresList[i].score);

        }

    }
}
public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}