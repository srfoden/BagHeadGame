/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:NonContiniousCameraMovement.cs
Purpose: To follow the cube and only move when the cube moves.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonContiniousCameraMovement_FourDimensions : MonoBehaviour
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
      

        if (target == null){
            Debug.LogWarning("No do not have a target.");
        }


        _myTransform = transform;
    }


    // Update is called once per frame
    void Update()
    {
        Quaternion rot = Quaternion.Euler(30f, 90f * counter, 0f);

        if (Input.GetKeyDown("a"))
        {
            counter++;
            if (counter == 4){
                counter = 0;
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);

       
    }

    void LateUpdate()
    {

        if (counter == 0)
        {
            _myTransform.position = new Vector3(target.position.x, target.position.y + 2.5f, target.position.z - walkDistance);
        }
        else if (counter == 1)
        {
            _myTransform.position = new Vector3(target.position.x - walkDistance, target.position.y + 2.5f, target.position.z);
        }
        else if (counter == 2){
            _myTransform.position = new Vector3(target.position.x, target.position.y + 2.5f, target.position.z + walkDistance);
        }
        else if (counter == 3){
            _myTransform.position = new Vector3(target.position.x + walkDistance, target.position.y + 2.5f, target.position.z);
        }

    }






}
