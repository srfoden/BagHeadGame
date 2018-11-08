/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:NonContiniousCameraMovement.cs
Purpose: To follow the cube and only move when the cube moves.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonContiniousCameraMovement : MonoBehaviour {


    public GameObject cube;
    public float speed = 5f;
    float posZ = -9.5f;

    int counter = 0;

    // Use this for initialization
    void Start()
    {


    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 cubepos = cube.transform.position;
        //Quaternion rot = Quaternion.Euler(0f, counter * 90f, 0f);

        if (Input.GetKey("up") && counter == 0 && cubepos.z >= posZ)
        {
            pos.z += speed * Time.deltaTime;
            posZ = cubepos.z;
        }
        if (Input.GetKey("up") && counter == 1)
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("up") && counter == 2)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("up") && counter == 3)
        {
            pos.x -= speed * Time.deltaTime;
        }
        transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {

    }


}
