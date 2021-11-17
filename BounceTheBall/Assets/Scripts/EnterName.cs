using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }

   public static void SubmitName(string username)
    {
        Debug.Log(username);
        int score = (int)ScoreManager.hiScoreCount;
        DreamloScoreTable.AddNewHighscore(username, score);
    }
}
