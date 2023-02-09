using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movement = 100f;
    public float jump = 200f;

    // Update is called once per frame
    void FixedUpdate()
    {

    if (Input.GetKey("d"))
    {
        rb.AddForce(new Vector2(movement * Time.deltaTime, 0));
    }

    if (Input.GetKey("a"))
    {
        rb.AddForce(new Vector2(-movement * Time.deltaTime, 0));
    }

    if (Input.GetKey("space"))
    {
        rb.AddForce(new Vector2(0, jump * Time.deltaTime));
    }
    }
}
