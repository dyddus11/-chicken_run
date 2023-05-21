using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public GameObject Land;
     public float jumpForce = 3f;
     public Vector3 _surfacePoint;
     public int jumpCount = 2;
     public bool jumping = false;
     public float jumpTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vector3.zero;

        Vector3 surfacePoint = Land.transform.position + (Land.transform.up * Land.transform.localScale.x / 2);
        transform.position = surfacePoint ;
        _surfacePoint = surfacePoint;
    }

     void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Land"))
        {
            jumpCount = 2;
            jumping = false;
            Debug.Log("tt");
        }
    }
     
     void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.CompareTag("Land"))
         {
             jumpCount = 2;
             Debug.Log("tt");

         }
     }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount <= 0)
            {
                return;
            }

            if (jumping)
            {
                jumpTime -= Time.deltaTime;
                
                if (jumpTime <= 0)
                {
                    jumpTime = 0.35f;
                    return;
                } 
            }
            
            // transform.position = Vector3.up;
            Rigidbody2D rd = GetComponent<Rigidbody2D>();
            rd.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            // jumpCount--;
            jumping = true; 
        }
    }
}
