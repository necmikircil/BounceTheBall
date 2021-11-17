using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Collider2D playerCd;


    public GameObject arrowToUp;
    public GameObject arrowToLeft;
    public GameObject arrowToRight;

    
    private void Start()
    {
        playerCd = GetComponent<Collider2D>();
        playerRb = GetComponent<Rigidbody2D>();
    }
   

    public void JumpUp()
    {
        playerRb.AddForce(Vector2.up * 350);
        FindObjectOfType<AudioManager>().PlaySound("Jump");

        
    }

    public void SetActiveArrowUp()
    {
        arrowToUp.SetActive(true);

    }

    public void JumpLeft()
    {
      playerRb.AddForce(Vector2.up * 200 + Vector2.left * 200);
        FindObjectOfType<AudioManager>().PlaySound("Jump");


    }

    public void SetActiveArrowToLeft()
    {
        arrowToLeft.SetActive(true);

    }


    public void JumpRight()
    {
      playerRb.AddForce(Vector2.up * 200 + Vector2.right * 200);
        FindObjectOfType<AudioManager>().PlaySound("Jump");

    }

    public void SetActiveArrowToRight()
    {
        arrowToRight.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Death")
            PlayerManager.gameOver = true;
    }


    




}
