using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSkins : MonoBehaviour
{
    public GameObject[] playerSkins;
    public GameObject[] unlockedSkins;
    public SkinBluePrint[] skinModels;
    int index;

    public Button buyButton;
    public Button selectButton;
    public Text priceText;
    public Image priceImage;
    
    

    void Start()
    {
        foreach(SkinBluePrint skin in skinModels)
        {
            if (skin.price == 0)
                skin.isUnlocked = true;
            else
                skin.isUnlocked = PlayerPrefs.GetInt(skin.name, 0)==0 ? false: true;


        }
        
        index = PlayerPrefs.GetInt("SelectedSkin", 0);
        foreach (GameObject skin in playerSkins)
            skin.SetActive(false);

        playerSkins[index].SetActive(true);
    }

    
    void Update()
    {
        if (index >= 10)
            index = 10;

        if (index < 0)
            index = 0;

        if(index == 0)
        {
            playerSkins[0].gameObject.SetActive(true);
        }

        UpdateUI();
    }

    public void Next()
    {
        index += 1;
        if (index > 10)
            return;

        for(int i = 0; i < playerSkins.Length; i++)
        {
            playerSkins[i].gameObject.SetActive(false);
            playerSkins[index].gameObject.SetActive(true);

            
        }
        SkinBluePrint s = skinModels[index];
        if (!s.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedSkin", index);
    }

    public void Previous()
    {
        index -= 1;
        if (index < 0)
            return;

        for (int i = 0; i < playerSkins.Length; i++) 
        {
            playerSkins[i].gameObject.SetActive(false);
            playerSkins[index].gameObject.SetActive(true);

        }
        SkinBluePrint s = skinModels[index];
        if (!s.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedSkin", index);

    }

    public void UnlockSkin()
    {
        SkinBluePrint s = skinModels[index];

        PlayerPrefs.SetInt(s.name, 1);
        PlayerPrefs.SetInt("SelectedSkin", index);
        s.isUnlocked = true;
        //Currency.coins = Currency.coins - s.price;
        PlayerPrefs.SetInt("NumberOfCurrency", Currency.coins -= s.price);
    }

    public void EquipSkin()
    {
        SkinBluePrint s = skinModels[index];

        
        
        

        s.isEquiped = true;
        
    }

    private void UpdateUI()
    {
        SkinBluePrint s = skinModels[index];
        //equipButton.gameObject.SetActive(false);
        priceText.text = "" + s.price;
        


        if (s.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);            
            selectButton.gameObject.SetActive(true);
            priceText.gameObject.SetActive(false);
            priceImage.gameObject.SetActive(false);
            

        }
        else
        {
            buyButton.gameObject.SetActive(true);
            priceText.gameObject.SetActive(true);
            priceImage.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(true);
            if (s.price <= PlayerPrefs.GetInt("NumberOfCurrency", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
        
        

    }


}
