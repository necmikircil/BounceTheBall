using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;

    public Sprite mutedSprite;
    public Sprite notMutedSprite;
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;

    }

    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);

    }

    private void Update()
    {
        if (isMuted)
            GetComponent<Image>().sprite = mutedSprite;
        else
            GetComponent<Image>().sprite = notMutedSprite;
    }
}
