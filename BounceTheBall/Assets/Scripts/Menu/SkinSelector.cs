using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    public SkinBluePrint[] skins;
    public Sprite[] playerSkins;

    public static int index;
    public GameObject player;
    

    void Start()
    {
        foreach(SkinBluePrint skin in skins)
        {
            if (skin.price == 0)
                skin.isUnlocked = true;
            else
                skin.isUnlocked = PlayerPrefs.GetInt(skin.name, 0)== 0 ? false: true ;

        }
        
        
        index = PlayerPrefs.GetInt("SelectedSkin", 0);
      
        player.GetComponent<SpriteRenderer>().sprite = playerSkins[index];

        
    }
}
