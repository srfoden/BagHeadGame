using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip gOver;
    
	// Use this for initialization
	void Start () {
        audioSource.clip = gOver;
        audioSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
