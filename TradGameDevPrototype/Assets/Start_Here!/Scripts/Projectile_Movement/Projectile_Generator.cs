using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Generator : MonoBehaviour {

    public GameObject projectilePrefab;
    public GameObject particleSystem;


    public float startTime;

    public float secondsBetweenProjectiles;

	// Use this for initialization
	void Start () {
        InvokeRepeating("ShootProjectile", startTime, secondsBetweenProjectiles);
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    void ShootProjectile(){
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
        //GameObject particle = Instantiate(particleSystem) as GameObject;
        //Debug.Log(particle.GetComponent<ParticleSystem>().isPlaying);
        //particle.GetComponent<ParticleSystem>().Play();
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        projectile.transform.position = pos;
        
        //particle.transform.position = transform.position;
    }
}
