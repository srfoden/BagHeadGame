using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Generator : MonoBehaviour {

    public GameObject projectilePrefab;

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
        projectile.transform.position = transform.position;
    }
}
