using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour {

    public float speed;

    public bool xDirection;
    public bool yDirection;
    public bool zDirection;

    public bool isFalling;

    public float xRange;
    public float yRange;
    public float zRange;

    public float fallTime;



    private float xSpeed;
    private float ySpeed;
    private float zSpeed;

    private float xOrigin;
    private float yOrigin;
    private float zOrigin;

    private int counter;
    private bool onGround;


    // Use this for initialization
    void Start () {
        xSpeed = speed;
        ySpeed = speed;
        zSpeed = speed;

        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;

        onGround = false;
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        if (xDirection){
            pos.x += xSpeed * Time.deltaTime;
            if (pos.x >= (xRange + xOrigin) || pos.x <= (-xRange + xOrigin))
            {
                xSpeed *= -1;
            }
        }
        if (yDirection){
            pos.y += ySpeed * Time.deltaTime;
            if (pos.y >= (yRange + yOrigin) || pos.y <= (-yRange + yOrigin))
            {
                ySpeed *= -1;
            }
        }
        if (zDirection){
            pos.z += zSpeed * Time.deltaTime;
            if (pos.z >= (zRange + zOrigin) || pos.z <= (-zRange + zOrigin))
            {
                zSpeed *= -1;
            }
        }
        transform.position = pos;

    }

    void OnCollisionEnter(Collision other)
    {
        if (isFalling)
        {
            if (other.gameObject.CompareTag("Player") && counter == 0)
            {
                StartCoroutine(DropPad());
                counter++;
            }
        }
    }


    IEnumerator DropPad()
    {
        yield return new WaitForSeconds(fallTime);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
    }

   
}
