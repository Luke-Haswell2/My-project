using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    bool touchingPlatform;
    public float angvel = 260;
    private Animator anim;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        anim = GetComponent<Animator>();

        isJumping = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack", false);

        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 8);
            
            isJumping=true;
        }

        if( (isJumping == true)   )
        {
            anim.SetBool("jump", true);
            if ((touchingPlatform == true) && rb.velocity.y < 0)
            {
                isJumping = false;
            }
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
            anim.SetBool("walk", true);
        }
        if (Input.GetKey("left"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(-2, rb.velocity.y);
            anim.SetBool("walk", true);
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
        if (Input.GetKey("x"))
        {
            rb.velocity = new Vector2(1, 0);
            anim.SetBool("attack", true);
        }

        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        print("colliding with " + collision.gameObject.tag);

        if (collision.gameObject.tag == "platform" )
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
