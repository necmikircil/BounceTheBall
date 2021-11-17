using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 direction;
    public float upSpeed;
    public float maxSpeed;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Screen.SetResolution(1080, 1920,FullScreenMode.ExclusiveFullScreen,60);

    }

    private void Update()
    {
        if (PlayerManager.isGameStarted == false)
            return;
       
        if(upSpeed < maxSpeed)
            
           upSpeed += 0.01f * Time.deltaTime;
        
        direction.y = upSpeed;
    }



    private void FixedUpdate()
    {
        

        controller.Move(direction * Time.fixedDeltaTime);
    }


    
}


