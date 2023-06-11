using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float maxAcceleration = 10f;
    public float maxXVelcotiy = 100f;
    public float acceleration = 10;
    public float distance = 0;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;
    
    private bool isHodingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;
    
     private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    void awake()
    {
        
    }

     void OnCollisionEnter(Collision other)
    {
   
    }
     
     void OnCollisionStay(Collision collision)
     {
       
     }

     private void Awake()
     {
         _animator = GetComponent<Animator>();
     }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
        
        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHodingJump = true;
                holdJumpTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHodingJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            if (isHodingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHodingJump = false;
                }
            }
            
            pos.y += velocity.y * Time.fixedDeltaTime;

            if (!isHodingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
          
            }


        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelcotiy;
            acceleration = maxAcceleration * (1 - velocityRatio);
            
            velocity.x += acceleration * Time.fixedDeltaTime;
            
            if (velocity.x >= maxXVelcotiy)
            {
                velocity.x = maxXVelcotiy;
            }
            
        }
       

        transform.position = pos;
    }
}
