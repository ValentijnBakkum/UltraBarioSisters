using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public int movementSpeed = 1;
    private bool direction; //true = right, false = left

    // Start is called before the first frame update
    void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction)
            transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
        else
            transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch(col.gameObject.tag){
            case "Pipe":
                direction = !direction;
                break;
            case "lava":
                Destroy(gameObject);
                break;
        }
    }
}
