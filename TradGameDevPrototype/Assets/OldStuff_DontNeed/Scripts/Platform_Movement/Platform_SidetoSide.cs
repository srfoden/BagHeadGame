using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_SidetoSide : MonoBehaviour {

    public float speed;
    public float leftAndRightEdge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Directions
        if (Mathf.Abs(pos.x) >= leftAndRightEdge)
        {
            speed *= -1;
        }
     
    }


}
