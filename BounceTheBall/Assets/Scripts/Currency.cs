using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static int coins;

    public Text currencyText;
    public Text _currencyText;
    
    void Start()
    {
        coins = PlayerPrefs.GetInt("NumberOfCurrency", 0);
        
    }

    
    void Update()
    {
        
        currencyText.text = "" + PlayerPrefs.GetInt("NumberOfCurrency",PlayerManager.numberOfCoins); 
        _currencyText.text = "" + PlayerPrefs.GetInt("NumberOfCurrency",PlayerManager.numberOfCoins); 


    }
}
