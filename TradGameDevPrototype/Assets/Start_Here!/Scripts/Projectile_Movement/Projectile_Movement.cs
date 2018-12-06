using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Movement : MonoBehaviour {

    public float speed;

    public bool xDirection;
    public bool xnegDirection;
    public bool yDirection;
    public bool ynegDirection;
    public bool zDirection;
    public bool znegDirection;

    public float xMax;
    public float zMax;

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
        else if (xnegDirection){
            xSpeed = -speed;
        }
        if (yDirection)
        {
            ySpeed = speed;
        }
        else if (ynegDirection)
        {
            ySpeed = -speed;
        }
        if (zDirection)
        {
            zSpeed = speed;
        }
        else if (znegDirection)
        {
            zSpeed = -speed;
        }

        onGround = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        float tangent = Mathf.Tan(inclinedAngle);
        //print(Mathf.Tan(inclinedAngle));

        if (xDirection || xnegDirection)
        {
            pos.x += xSpeed * Time.deltaTime;

            if (xDirection){
                if (pos.x > xMax){
                    Destroy(this.gameObject);
                }
            }
            else if (xnegDirection){
                if (pos.x < xMax){
                    Destroy(this.gameObject);
                }
            }
           
        }

        if (yDirection || ynegDirection)
        {
            pos.y += (ySpeed* inclinedAngle) * Time.deltaTime;
          
        }
        if (zDirection || znegDirection)
        {
            pos.z += zSpeed * Time.deltaTime;
      
        }
        transform.position = pos;

    }

  

}

