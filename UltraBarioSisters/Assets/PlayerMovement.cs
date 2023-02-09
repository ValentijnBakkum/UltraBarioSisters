using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movement = 100f;
    public float airmovement = 20f;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float jumpforce = 10f;

    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    public float maxSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey("d"))
        {
            if(GroundCheck()){
                rb.AddForce(new Vector2(movement * Time.deltaTime, 0));
            }else{
                rb.AddForce(new Vector2(airmovement * Time.deltaTime, 0));
            }
        }
        if (Input.GetKey("a"))
        {
            if(GroundCheck()){
                rb.AddForce(new Vector2(-movement * Time.deltaTime, 0));
            }else{
                rb.AddForce(new Vector2(-airmovement * Time.deltaTime, 0));
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rb.AddForce(transform.up*jumpforce,ForceMode2D.Impulse);
        }

        //make the player fall quicker
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        //set max velocity of the player when moving
        if(rb.velocity.x >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x <= -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance,boxSize);
    }
    private bool GroundCheck()
    {
        if(Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,maxDistance,layerMask))
        {
            return true;
        }
        else{
            return false;
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        switch(col.gameObject.tag){
            case "enemy":
            case "lava":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "enemyHead":
                Debug.Log("test");
                Destroy(col.transform.parent.gameObject);
                break;
            case "Finish":
                Debug.Log("FINISHED");
                break;
        }
    }
}
