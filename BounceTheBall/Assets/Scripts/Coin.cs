using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
         
    void Update()
    {
        transform.Rotate(0, 150 * Time.deltaTime, 0);


    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfCoins += 1;
            
            ScoreManager.scoreCount += 500;
            Destroy(gameObject);

        }
    }
}
