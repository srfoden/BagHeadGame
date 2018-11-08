using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Movement : MonoBehaviour {

    public float speed;

    public bool xDirection;
    public bool yDirection;
    public bool zDirection;

    private float xSpeed;
    private float ySpeed;
    private float zSpeed;

    private int counter;
    private bool onGround;

    public float inclinedAngle;



    // Use this for initialization
    void Start()
    {
        xSpeed = 0;
        ySpeed = 0;
        zSpeed = 0;

        if (xDirection){
        xSpeed = speed;
        }
        if (yDirection)
        {
            ySpeed = speed;
        }
        if (zDirection)
        {
            zSpeed = speed;
        }

        onGround = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float tangent = Mathf.Tan(inclinedAngle);
        print(Mathf.Tan(inclinedAngle));
        /*
        if (xDirection)
        {
            pos.x += xSpeed * Time.deltaTime;
           
        }
        */
        if (yDirection)
        {
            pos.y -= (ySpeed* inclinedAngle) * Time.deltaTime;
          
        }
        if (zDirection)
        {
            pos.z -= zSpeed * Time.deltaTime;
      
        }
        transform.position = pos;

    }

  

}

