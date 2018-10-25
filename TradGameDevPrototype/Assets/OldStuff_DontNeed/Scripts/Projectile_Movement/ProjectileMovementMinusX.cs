using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementMinusX : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;
        transform.position = pos;
    }
}
