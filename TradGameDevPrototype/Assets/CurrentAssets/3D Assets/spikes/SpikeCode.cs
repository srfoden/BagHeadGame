﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCode : MonoBehaviour {

    public float speed;
    public float inclinedAngle;
    public float zMax, zMin;

    float i = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.z > zMax){
            speed *= -1;
        }
        if (transform.position.z < zMin){
            speed *= -1;
        }

        Vector3 pos = transform.position;
        pos.z += speed * Time.deltaTime;
        pos.y -= (speed * inclinedAngle) * Time.deltaTime;

        transform.position = pos;

        Quaternion rot = Quaternion.Euler(0f,90f,1 * i);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 20f);

        i++;


    }
}
