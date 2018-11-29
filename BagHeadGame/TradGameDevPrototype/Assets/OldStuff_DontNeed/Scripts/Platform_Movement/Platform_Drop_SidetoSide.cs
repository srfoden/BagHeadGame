using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Drop_SidetoSide : MonoBehaviour
{
    private int counter;

    public float TimetoWait;
    public bool onGround;


    public float speed;
    public float leftAndRightEdge;

    // Use this for initialization
    void Start()
    {
        onGround = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && counter == 0)
        {
            StartCoroutine(DropPad());
            counter++;
        }
    }

    IEnumerator DropPad()
    {
        yield return new WaitForSeconds(TimetoWait);
        Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
    }
}