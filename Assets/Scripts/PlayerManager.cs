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
    [Range(1f,5.0f)]
    private float accelerationSpeed;

    private void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }

        if(!Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            HaltMovement();
        }

        _Animator.SetFloat("SpeedX", speedX);
        _Animator.SetFloat("SpeedZ", speedZ);
    }


    private void MoveLeft()
    {
        if(speedX > -maxSpeed)
        {
            speedX -= accelerationSpeed * Time.deltaTime;
        }
    }
    
    private void MoveRight()
    {
        if(speedX < maxSpeed)
        {
            speedX += accelerationSpeed * Time.deltaTime;
        }
    }
    
    private void MoveForward()
    {
        if(speedZ < maxSpeed)
        {
            speedZ += accelerationSpeed * Time.deltaTime;
        }      
    }

    private void HaltMovement()
    {
        if(speedZ > 0.0f)
        {
            speedZ -= accelerationSpeed * Time.deltaTime;
        }
        else if(speedZ < 0.0f)
        {
            speedZ = 0.0f;
        }
    }
}
