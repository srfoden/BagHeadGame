/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:CubeMovementWithJump.cs
Purpose: Cube Movement with Jump as well.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementWithJump : MonoBehaviour {

    public float speed = 5f;

    public bool onGround;
    private Rigidbody rb;

    public GameObject Cube;

	// Use this for initialization
	void Start () {
        onGround = true;
        rb = GetComponent<Rigidbody>();
		
	}

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("up")){
            pos.z += speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey("down"))
        {
            pos.z -= speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey("right"))
        {
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey("left"))
        {
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
        if(onGround){
            if (Input.GetKeyDown("a")){
                rb.velocity = new Vector3(0f,8f,0f);
                onGround = false;
            }
        }
       
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}


}
