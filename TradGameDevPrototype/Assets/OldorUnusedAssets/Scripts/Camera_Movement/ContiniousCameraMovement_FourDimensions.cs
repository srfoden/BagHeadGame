/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:ContiniousCameraMovement.cs
Purpose: Continious Camera Movement that pivots at turn as well.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT DOES NOT WORK/DO ANYTHING YET


public class ContiniousCameraMovement_FourDimensions : MonoBehaviour
{

    public float speed = 5f;
    public float rotationspeed = 10f;
    public float zMax;
    public float zMin;
    public float xMax;
    public float xMin;

    int counter = 0;

    // Use this for initialization
    void Start()
    {


    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Quaternion rot = Quaternion.Euler(30f, 90f * counter, 0f);


        if (counter == 0 && pos.z > zMax)
        {
            counter++;

        }
        else if (counter == 1 && pos.x > xMax)
        {
            counter++;
        }
        else if (counter == 2 && pos.z < zMin)
        {
            counter++;
        }
        else if (counter == 3 && pos.x < xMin)
        {
            counter = 0;
        }

        if (counter == 0)
        {
            pos.z += speed * Time.deltaTime;
        }
        else if (counter == 1)
        {
            pos.x += speed * Time.deltaTime;
        }
        else if (counter == 2)
        {
            pos.z -= speed * Time.deltaTime;
        }
        else if (counter == 3)
        {
            pos.x -= speed * Time.deltaTime;

        }
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationspeed);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {

    }


}
