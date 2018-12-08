using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baghead_Movement : MonoBehaviour
{

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            anim.SetBool("isDown", true);
        }
        if (Input.GetKeyUp("up"))
        {
            anim.SetBool("isDown", false);
        }
    }



}

