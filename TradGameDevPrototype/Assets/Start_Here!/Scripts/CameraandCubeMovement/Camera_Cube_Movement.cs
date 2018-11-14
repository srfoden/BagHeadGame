using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Cube_Movement : MonoBehaviour {
    private Animator anim;

    public float speed = 5f;
    public float posZ;
    public float posY;

    public int floorLevel;

    public float xMax1, xMax2, xMax3, xMax4;
    public float xMin1, xMin2, xMin3, xMin4;
    public float zMax1, zMax2, zMax3,zMax4;
    public float zMin1,zMin2, zMin3,zMin4;

    private int test;


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
    private int sum;
    public int versionNUM;

    public int counter;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sum = 0;
        floorLevel = 0;
        test = 0;
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
        //Quaternion rot = Quaternion.Euler(30f, 90f * counter, 0f);

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
        if (versionNUM == 4)
        {
            if (Input.GetKey("up"))
            {
                pos.x += Movementspeed * Time.deltaTime; //Go forward
            }
            if (Input.GetKey("down"))
            {
                pos.x -= Movementspeed * Time.deltaTime; //Go backward
            }
            if (Input.GetKey("right"))
            {
                pos.z -= Movementspeed * Time.deltaTime;  //Go right

            }
            if (Input.GetKey("left"))
            {
                pos.z += Movementspeed * Time.deltaTime;   //Go left
            }
        }
        /*
        if (Input.GetKey("up")){
            pos.y += ((Movementspeed * Time.deltaTime) * .05f);
        }
        else if (Input.GetKey("down"))
        {
            pos.y -= ((Movementspeed * Time.deltaTime) * .05f);
        }
        */

        transform.position = pos;         //Set the transform.position to be the Vector3

    
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0f, yVelocity, 0f);  //Set velocity on cube
                anim.SetBool("isSpace",true);
                onGround = false;
            }
        }

    }

        //When the cube collides with the platform
      void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.CompareTag("Ground"))
            {
                onGround = true;
            anim.SetBool("isSpace", false);
        }

         
        }
    

    void LateUpdate()
    {
        Vector3 pos = transform.position;  //Get the position part of transform
        Quaternion rot1 = Quaternion.Euler(30f, 180f, 0f);
        Quaternion rot2 = Quaternion.Euler(30f, 270f, 0f);
        Quaternion rot3 = Quaternion.Euler(30f, 0f, 0f);
        Quaternion rot4 = Quaternion.Euler(30f, 90f, 0f);

        Quaternion Brot1 = Quaternion.Euler(0f, 180f, 0f);
        Quaternion Brot2 = Quaternion.Euler(0f, 270f, 0f);
        Quaternion Brot3 = Quaternion.Euler(0f, 0f, 0f);
        Quaternion Brot4 = Quaternion.Euler(0f, 90f, 0f);


        if (pos.x > xMax1){
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            versionNUM = 3;         
        }
        if (pos.z < zMin1)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot2, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Brot2, Time.deltaTime * rotationSpeed);
            versionNUM = 2;
        }
        if (pos.x < xMin1){
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot3, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Brot3, Time.deltaTime * rotationSpeed);
            versionNUM = 1;
        }
        if (pos.z > zMax1 && pos.y > 4)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot4, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Brot4, Time.deltaTime * rotationSpeed);
            versionNUM = 4;
        }


        if (pos.y > 5 && pos.x > xMax2 )
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            versionNUM = 3;
        }
        if (pos.z < zMin2 && pos.y > 6)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot2, Time.deltaTime * rotationSpeed);
            versionNUM = 2;
        }
        if (pos.x < xMin2 && pos.y > 7)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot3, Time.deltaTime * rotationSpeed);
            versionNUM = 1;
        }
        if (pos.z > zMax2 && pos.y > 8)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot4, Time.deltaTime * rotationSpeed);
            versionNUM = 4;
        }

        if (pos.y > 9 && pos.x > xMax3)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            versionNUM = 3;
        }
        if (pos.z < zMin3 && pos.y > 10)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot2, Time.deltaTime * rotationSpeed);
            versionNUM = 2;
        }
        if (pos.x < xMin3 && pos.y > 11)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot3, Time.deltaTime * rotationSpeed);
            versionNUM = 1;
        }
        if (pos.z > zMax3 && pos.y > 12)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot4, Time.deltaTime * rotationSpeed);
            versionNUM = 4;
        }

        if (pos.y > 13 && pos.x > xMax4)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            versionNUM = 3;
        }
        if (pos.z < zMin4 && pos.y > 14)
        {
            cameraPOS.rotation = Quaternion.Slerp(cameraPOS.rotation, rot2, Time.deltaTime * rotationSpeed);
            versionNUM = 2;
        }
       




        if (versionNUM == 1)
        {
            cameraPOS.position = new Vector3(pos.x, pos.y + 3.5f, pos.z - walkDistance);
        }

        else if (versionNUM == 2){
            cameraPOS.position = new Vector3(pos.x + walkDistance, pos.y + 3.5f, pos.z);
        }

        else if (versionNUM == 3){
            cameraPOS.position = new Vector3(pos.x, pos.y + 3.5f, pos.z + walkDistance);
        }

        else if (versionNUM == 4)
        {
            cameraPOS.position = new Vector3(pos.x - walkDistance, pos.y + 3.5f, pos.z);
        }



    }

  

}
