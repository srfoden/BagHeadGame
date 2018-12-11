using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Script : MonoBehaviour {

    //AUDIO
    public AudioClip audioClip;
    public AudioSource audioSource;

    //ANIMATION
    private Animator anim;

    //PROJECTILE GENERATOR
    public GameObject projectilePrefab;
    public float startTime;
    public float secondsBetweenProjectiles;

    //PROJECTILE MOVEMENT
    public float speed;

    public bool xDirection, xnegDirection, yDirection, ynegDirection, zDirection, znegDirection;

    public float xMax, zMax;

    public float inclinedAngle;

    private float xSpeed, ySpeed, zSpeed;

    private int counter;



    // Use this for initialization
    void Start () {

        audioSource.clip = audioClip;
        audioSource.Play();

        anim = GetComponent<Animator>();

        xSpeed,ySpeed,zSpeed = 0;

        xSpeed = xDirection. * speed + xnegDirection * -speed;
        ySpeed = yDirection * speed + ynegDirection * -speed;
        zSpeed = zDirection * speed + znegDirection * -speed;
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
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        projectile.transform.position = pos;

    }
}
