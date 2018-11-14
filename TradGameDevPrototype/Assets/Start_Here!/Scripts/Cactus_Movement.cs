using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus_Movement : MonoBehaviour {

    public float farEdge;
    public float frontEdge;
    public float rightEdge;
    public float leftEdge;

    public float xSpeed;
    public float zSpeed;

    private float chanceToChangeDirections;

    // Use this for initialization
    void Start () {
        chanceToChangeDirections = .02f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += xSpeed * Time.deltaTime;
        pos.z += zSpeed * Time.deltaTime;
        pos.y += (xSpeed * Time.deltaTime)* .05f;
        transform.position = pos;

        if (pos.x < frontEdge){
            xSpeed = Mathf.Abs(xSpeed);
        }
        else if (pos.x > farEdge){
            xSpeed = -Mathf.Abs(xSpeed);
        }
        else if (Random.value < chanceToChangeDirections){
            xSpeed *= -1;
        }

        if (pos.z < rightEdge)
        {
            zSpeed = Mathf.Abs(zSpeed);
        }
        else if (pos.z > leftEdge)
        {
            zSpeed = -Mathf.Abs(zSpeed);
        }
        else if (Random.value < chanceToChangeDirections){
            zSpeed *= -1;
        }
    }
}
