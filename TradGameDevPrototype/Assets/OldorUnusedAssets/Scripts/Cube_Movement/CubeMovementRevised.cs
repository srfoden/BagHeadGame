/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:CubeMovementRevisited.cs
Purpose: Fixing up CubeMovementWithJump
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementRevised : MonoBehaviour
{

    public float Movementspeed;   //Speed of the cube
    public float yVelocity;            //yVal for Speed when cube jumps
    private bool onGround;         //boolean to keep track if Cube is on ground
    private Rigidbody rb;         //rigidbody component from Inspector being used in Script

    // Use this for initialization
    void Start()
    {
        onGround = true;         //Cube starts off on the ground.
        rb = GetComponent<Rigidbody>();    //Set the rigidbody in code to the component seen in the Inspector

    }

    //FixedUpdate will have the same frame rate on any computer, where Update frame rate will differ depending on the computer being used.
    void Update()
    {
        Vector3 pos = transform.position;  //Get the position part of transform
        if (Input.GetKey("up"))
        {
            pos.z += Movementspeed * Time.deltaTime; //Go forward
        }
        if (Input.GetKey("down"))
        {
            pos.z -= Movementspeed * Time.deltaTime; //Go backward
        }
        if (Input.GetKey("right"))
        {
            pos.x += Movementspeed * Time.deltaTime;  //Go right
          
        }
        if (Input.GetKey("left"))
        {
            pos.x -= Movementspeed * Time.deltaTime;   //Go left
        }

        transform.position = pos;         //Set the transform.position to be the Vector3

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0f, yVelocity, 0f);  //Set velocity on cube
                onGround = false; 
            }
        }

    }

    //When the cube collides with the platform
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }




}
