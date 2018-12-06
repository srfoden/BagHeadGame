using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_ForwardBack : MonoBehaviour
{

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
        pos.z += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Directions
        if (pos.z >= (topAndBottomEdge + originPoint) || pos.z <= (-topAndBottomEdge + originPoint))
        {
            speed *= -1;
        }

    }
}
