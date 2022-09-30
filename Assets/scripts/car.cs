using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    bool touchingPlatform;
    public float angvel = 260;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
       


    }

    // Update is called once per frame
    void Update()
    {
    

        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 8);

           
        }

        


        if (Input.GetKeyDown("down") && touchingPlatform)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 20);
        }
        if (Input.GetKey("right"))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(2, rb.velocity.y);
            
        }
        if (Input.GetKey("left"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(-2, rb.velocity.y);
           
        }
        if (Input.GetKeyDown("l") && touchingPlatform)
        {
            rb.velocity = new Vector2(8, 8);
            rb.angularVelocity = -angvel;
        }
        if (Input.GetKeyDown("k") && touchingPlatform)
        {
            rb.velocity = new Vector2(-8, 8);
            rb.angularVelocity = angvel;
        }
        if (Input.GetKey("a"))
        {
            rb.angularVelocity = 100;
        }
        if (Input.GetKey("s"))
        {
            rb.angularVelocity = -100;
        }
        


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        print("colliding with " + collision.gameObject.tag);

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            touchingPlatform = false;
        }
    }


}
