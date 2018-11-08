/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:NonContiniousCameraMovement.cs
Purpose: To follow the cube and only move when the cube moves.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecondWay : MonoBehaviour
{



    public GameObject cube;
    public float speed = 5f;
    public float posZ;
    public float posY;

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public Transform _myTransform;
    public float rotationSpeed;

    private float x;
    private float y;

    public int counter;

    // Use this for initialization
    void Start()
    {


        if (target == null)
        {
            Debug.LogWarning("No do not have a target.");
        }


        _myTransform = transform;
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    void LateUpdate()
    {
       
         _myTransform.position = new Vector3(target.position.x, target.position.y + 2.5f, target.position.z - walkDistance);
         
    }



}
