using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserRegister : MonoBehaviour
{
    public static InputField inputName;
    private int usersCount;
    private string[] userNames;

    private void Start()
    {
        usersCount = PlayerPrefs.GetInt("UsersCount", 0);
        if(usersCount > 0)
        {
            userNames = new string[usersCount];
            for (int i = 0;  i < usersCount; i++){
                userNames[i] = PlayerPrefs.GetString("User" + i, string.Empty);
            }

        }
    }


    public void SaveUserName()
    {
        PlayerPrefs.SetString("User" + usersCount, inputName.text);
        usersCount++;
        PlayerPrefs.SetInt("UsersCount", usersCount);
    }
}
