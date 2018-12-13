using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Script : MonoBehaviour {

    //AUDIO
    public AudioClip Background;
    public AudioClip GameOver;
    public AudioSource audioSource;

    //ANIMATION
    private Animator anim;

    //PROJECTILE GENERATOR
    public GameObject projectilePrefab;
    public float startTime;
    public float secondsBetweenProjectiles;

    //PROJECTILE MOVEMENT
    public float projspeed;

    public bool xDirection, xnegDirection, yDirection, ynegDirection, zDirection, znegDirection;

    public float xMax, zMax;

    public float inclinedAngle;

    private float xSpeed, ySpeed, zSpeed;

    private int counter;


    //CAMERA AND PLAYER MOVEMENT

    public float speed = 5f;
 

    public float xMax1, xMax2, xMax3, xMax4;
    public float xMin1, xMin2, xMin3, xMin4;
    public float zMax1, zMax2, zMax3,zMax4;
    public float zMin1,zMin2, zMin3,zMin4;

    public float yNum1, yNum2, yNum3, yNum4, yNum5, yNum6, yNum7, yNum8, yNum9, yNum10, yNum11;

    public float Movementspeed;   //Speed of the cube
    public float yVelocity;            //yVal for Speed when cube jumps
    public bool onGround;         //boolean to keep track if Cube is on ground
    private Rigidbody rb;         //rigidbody component from Inspector being used in Script

    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    public Transform cameraPOS;
    public float rotationSpeed;

    private float x;
    private float y;
    private int sum;
    public int versionNUM;

    public int turn1, turn2, turn3, turn4, turn5, turn6, turn7, turn8, turn9, turn10, turn11, turn12, turn13, turn14, turn15, turn16;



    void  Start () {

        audioSource.clip = Background;
        audioSource.Play();

        anim = GetComponent<Animator>();

        xSpeed = 0;
        ySpeed = 0;
        zSpeed = 0;

        turn1 = 0;
        turn2 = 0;
        turn3 = 0;
        turn4 = 0;
        turn5 = 0;
        turn6 = 0;
        turn7 = 0;
        turn8 = 0;
        turn9 = 0;
        turn10 = 0;
        turn11 = 0;
        turn12 = 0;
        turn13 = 0;
        turn14 = 0;
        turn15 = 0;
        turn16 = 0;

        rb = GetComponent<Rigidbody>();    //Set the rigidbody in code to the component seen in the Inspector


        if (xDirection){
            xSpeed = projspeed;
        }
        else if (xnegDirection)
        {
            xSpeed = -projspeed;
        }
        if (yDirection)
        {
            ySpeed = projspeed;
        }
        else if (ynegDirection)
        {
            ySpeed = -projspeed;
        }
        if (zDirection)
        {
            zSpeed = projspeed;
        }
        else if (znegDirection)
        {
            zSpeed = -projspeed;
        }



    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("up"))
        {
            anim.SetBool("isDown", true);
        }
        if (Input.GetKeyUp("up"))
        {
            anim.SetBool("isDown", false);
        }

      

        Vector3 pos = transform.position;  //Get the position part of transform

        if ((versionNUM == 1 && Input.GetKey("up")) || (versionNUM == 2 && Input.GetKey("right")) || (versionNUM == 3 && Input.GetKey("down")) || (versionNUM == 4 && Input.GetKey("left")))
        {
            pos.z += Movementspeed * Time.deltaTime; //Go forward
        }
        if ((versionNUM == 1 && Input.GetKey("down")) || (versionNUM == 2 && Input.GetKey("left")) || (versionNUM == 3 && Input.GetKey("up")) || (versionNUM == 4 && Input.GetKey("right")))
        {
            pos.z -= Movementspeed * Time.deltaTime; //Go forward
        }
        if ((versionNUM == 1 && Input.GetKey("right")) || (versionNUM == 2 && Input.GetKey("down")) || (versionNUM == 3 && Input.GetKey("left")) || (versionNUM == 4 && Input.GetKey("up")))
        {
            pos.x += Movementspeed * Time.deltaTime; //Go forward
        }
        if ((versionNUM == 1 && Input.GetKey("left")) || (versionNUM == 2 && Input.GetKey("up")) || (versionNUM == 3 && Input.GetKey("right")) || (versionNUM == 4 && Input.GetKey("down")))
        {
            pos.x -= Movementspeed * Time.deltaTime; //Go forward
        }


        transform.position = pos;         //Set the transform.position to be the Vector3


     

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * yVelocity, ForceMode.Impulse);
                anim.SetBool("isSpace", true);
                onGround = false;

            }
        }

        if (transform.position.y < -10f){

            ChangeScene("GameOver");
        }


    }

    //When the cube collides with the platform
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            onGround = true;
            anim.SetBool("isSpace", false);
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            ChangeScene("GameOver");
        }

    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        projectile.transform.position = pos;

    }


     void LateUpdate()
    {

        Vector3 pos = transform.position;  //Get the position part of transform

        Quaternion rot1 = Quaternion.Euler(15f, 180f, 0f);
        Quaternion rot2 = Quaternion.Euler(15f, 270f, 0f);
        Quaternion rot3 = Quaternion.Euler(15f, 0f, 0f);
        Quaternion rot4 = Quaternion.Euler(15f, 90f, 0f);

        Quaternion Brot1 = Quaternion.Euler(0f, 180f, 0f);
        Quaternion Brot2 = Quaternion.Euler(0f, 270f, 0f);
        Quaternion Brot3 = Quaternion.Euler(0f, 0f, 0f);
        Quaternion Brot4 = Quaternion.Euler(0f, 90f, 0f);

        if (turn1 == 0 && pos.x > xMax1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            versionNUM = 3;
        }
        if (turn2 == 0  && pos.z < zMin1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot2, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot2, Time.deltaTime * rotationSpeed);
            turn1++;
            versionNUM = 2;
        }
        if (turn3 == 0 && pos.x < xMin1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot3, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot3, Time.deltaTime * rotationSpeed);
            turn2++;
            versionNUM = 1;
        }
        /*
        if (turn4 == 0 && pos.z < zMin1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot4, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot4, Time.deltaTime * rotationSpeed);
            turn3++;
            versionNUM = 4;
        }

        /*
        if (turn5 == 0 && pos.x < xMin1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn4++;
            versionNUM = 1;
        }
        if (turn6 == 0 && pos.z > zMax1 && pos.y > yNum1)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn5++;
            versionNUM = 4;
        }

        if (turn7 == 0 && pos.y > yNum2 && pos.x > xMax2)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn6++;
            versionNUM = 3;
        }
        if (turn8 == 0 && pos.z < zMin2 && pos.y > yNum3)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn7++;
            versionNUM = 2;
        }
        if (turn9 == 0 && pos.x < xMin2 && pos.y > yNum4)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn8++;
            versionNUM = 1;
        }
        if (turn10 == 0 && pos.z > zMax2 && pos.y > yNum5)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn9++;
            versionNUM = 4;
        }

        if (turn11 == 0 && pos.y > yNum6 && pos.x > xMax3)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn10++;
            versionNUM = 3;
        }
        if (turn12 == 0 && pos.z < zMin3 && pos.y > yNum7)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn11++;
            versionNUM = 2;
        }
        if (turn13 == 0 && pos.x < xMin3 && pos.y > yNum8)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn12++;
            versionNUM = 1;
        }
        if (turn14 == 0 && pos.z > zMax3 && pos.y > yNum9)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn13++;
            versionNUM = 4;
        }

        if (turn15 == 0 && pos.y > yNum10 && pos.x > xMax4)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn14++;
            versionNUM = 3;
        }
        if (turn16 == 0 && pos.z < zMin4 && pos.y > yNum11)
        {
            cameraPOS.rotation = Quaternion.Lerp(cameraPOS.rotation, rot1, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Brot1, Time.deltaTime * rotationSpeed);
            turn15++;
            versionNUM = 2;
        }
        */

        if (versionNUM == 1)
        {
           
            cameraPOS.position = new Vector3(pos.x, pos.y + 3.5f, pos.z - walkDistance);
        }

        else if (versionNUM == 2)
        {
    
            cameraPOS.position = new Vector3(pos.x + walkDistance, pos.y + 3.5f, pos.z);
        }

        else if (versionNUM == 3)
        {
   
            cameraPOS.position = new Vector3(pos.x, pos.y + 3.5f, pos.z + walkDistance);
        }

        else if (versionNUM == 4)
        {
         
            cameraPOS.position = new Vector3(pos.x - walkDistance, pos.y + 3.5f, pos.z);
        }
       

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform")){
            transform.parent = other.gameObject.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }

    }

}
