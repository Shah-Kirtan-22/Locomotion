using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator _Animator;
    private float speedX = 0.0f;  // this will track movements towards either sides (left/right turns)
    private float speedZ = 0.0f;  // this will be the speed in the forward direction
    private float maxSpeed = 2.0f;  // this is the speed needed to reach the final animation state

    [SerializeField]
    [Range(1f,2.5f)]
    private float accelerationSpeed;  // the acceleration can be controlled from the inspector

    private void Start()
    {
        _Animator = GetComponent<Animator>();  // get the animator component and store it for future use
        Time.timeScale = 0.5f;  // the application will work at 0.5 speed the real time
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  
        {
            MoveLeft();  // call the method to turn left
        }
        
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();  // call the method to turn right
        }
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();  // call the method to move forwards
        }

        if(!Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            HaltMovement();  // calls the method when the player does not provide any input
        }

        _Animator.SetFloat("SpeedX", speedX);
        _Animator.SetFloat("SpeedZ", speedZ);
    }


    private void MoveLeft()
    {
        if(speedX > -maxSpeed)
        {
            speedX -= accelerationSpeed * Time.deltaTime;  // move the player in the negative X axis - i.e., left
        }
    }
    
    private void MoveRight()
    {
        if(speedX < maxSpeed)
        {
            speedX += accelerationSpeed * Time.deltaTime;  // move the player in the positive X axis
        }
    }
    
    private void MoveForward()
    {
        if(speedZ < maxSpeed)
        {
            speedZ += accelerationSpeed * Time.deltaTime;  // move the player along the Z axis - i.e., forward
        }      
    }

    private void HaltMovement()
    {
        if(speedZ > 0.0f)
        {
            speedZ -= accelerationSpeed * Time.deltaTime;  // move the player in the negative Z axis - i.e, stop
        }
        else if(speedZ < 0.0f)
        {
            speedZ = 0.0f;
        }
    }
}
