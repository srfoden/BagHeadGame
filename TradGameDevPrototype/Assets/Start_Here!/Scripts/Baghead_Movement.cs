using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baghead_Movement : MonoBehaviour {

    private Animator anim;
   
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            anim.SetBool("isDown", true);
        }
        else{
            anim.SetBool("isDown",false);
        }

        if (Input.GetKeyUp("p")){
            anim.SetBool("isSpace", true);
        }
       


    }
}
