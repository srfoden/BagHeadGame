/*
Programmer: Scott Foden
Date: Sept 30, 2018
FileName:ContiniousCameraMovementNoPivot.cs
Purpose: Continious Camera Movement With No Pivot
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContiniousCameraMovementNoPivot : MonoBehaviour {

    public float CameraSpeed;

    int counter = 0;

	// Use this for initialization
	void Start () {
   

    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.z += CameraSpeed * Time.deltaTime;

        transform.position = pos;

    }
}
