using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_UpandDown : MonoBehaviour {

    public float speed;
    public float originPoint;
    public float topAndBottomEdge;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Directions
        if (pos.y >= (topAndBottomEdge + originPoint) || pos.y <= (-topAndBottomEdge + originPoint))
        {
            speed *= -1;
        }

    }
}
