using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Cube_Movement : MonoBehaviour {

    public float speed = 5f;
    public float posZ;
    public float posY;

    public float Movementspeed;   //Speed of the cube
    public float yVelocity;            //yVal for Speed when cube jumps
    public bool onGround;         //boolean to keep track if Cube is on ground
    private Rigidbody rb;         //rigidbody component from Inspector being used in Script

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public Transform cameraPOS;
    public float rotationSpeed;

    private float x;
    private float y;

    public int versionNUM;

    public int counter;

    // Use this for initialization
    void Start () {

        if (target == null)
        {
            Debug.LogWarning("No do not have a target.");
        }

        onGround = true;         //Cube starts off on the ground.
        rb = GetComponent<Rigidbody>();    //Set the rigidbody in code to the component seen in the Inspector

        counter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;  //Get the position part of transform
       
        if (versionNUM == 1){
            if (Input.GetKey("up"))
            {
                pos.z += Movementspeed * Time.deltaTime; //Go forward
            }
            if (Input.GetKey("down"))
            {
                pos.z -= Movementspeed * Time.deltaTime; //Go backward
            }
            if (Input.GetKey("right"))
            {
                pos.x += Movementspeed * Time.deltaTime;  //Go right

            }
            if (Input.GetKey("left"))
            {
                pos.x -= Movementspeed * Time.deltaTime;   //Go left
            }
        }

        if (versionNUM == 2){
            if (Input.GetKey("up"))
            {
                pos.x -= Movementspeed * Time.deltaTime; //Go forward
            }
            if (Input.GetKey("down"))
            {
                pos.x += Movementspeed * Time.deltaTime; //Go backward
            }
            if (Input.GetKey("right"))
            {
                pos.z += Movementspeed * Time.deltaTime;  //Go right

            }
            if (Input.GetKey("left"))
            {
                pos.z -= Movementspeed * Time.deltaTime;   //Go left
            }
        }
        if (versionNUM == 3)
        {
            if (Input.GetKey("up"))
            {
                pos.z -= Movementspeed * Time.deltaTime; //Go forward
            }
            if (Input.GetKey("down"))
            {
                pos.z += Movementspeed * Time.deltaTime; //Go backward
            }
            if (Input.GetKey("right"))
            {
                pos.x -= Movementspeed * Time.deltaTime;  //Go right

            }
            if (Input.GetKey("left"))
            {
                pos.x += Movementspeed * Time.deltaTime;   //Go left
            }
        }



        transform.position = pos;         //Set the transform.position to be the Vector3

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0f, yVelocity, 0f);  //Set velocity on cube
                onGround = false;
            }
        }

        if (Input.GetKeyDown("a"))
        {
            counter++;
            if (counter == 4)
            {
                counter = 0;
            }
        }


    }

        //When the cube collides with the platform
      void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.CompareTag("Ground"))
            {
                onGround = true;
            }

         
        }
    

    void LateUpdate()
    {
        Vector3 pos = transform.position;  //Get the position part of transform

        if (versionNUM == 1)
        {
            cameraPOS.position = new Vector3(pos.x, pos.y + 2.5f, pos.z - walkDistance);
        }

        else if (versionNUM == 2){
            cameraPOS.position = new Vector3(pos.x + walkDistance, pos.y + 2.5f, pos.z);
        }

        else if (versionNUM == 3){
            cameraPOS.position = new Vector3(pos.x, pos.y + 2.5f, pos.z + walkDistance);
        }

    }

  

}
