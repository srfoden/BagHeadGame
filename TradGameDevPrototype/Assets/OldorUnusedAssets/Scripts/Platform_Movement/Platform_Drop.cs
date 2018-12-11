using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop : MonoBehaviour {
    private int counter;

    public float TimetoWait;
    public bool onGround;

	// Use this for initialization
	void Start () {
        onGround = false;
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && counter == 0){
            StartCoroutine(DropPad());
            counter++;
        }
    }


    IEnumerator DropPad(){
        yield return new WaitForSeconds(TimetoWait);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
    }

}
