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
    HelperScript helper;
    public GameObject bird;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        anim = GetComponent<Animator>();

        isJumping = false;
        helper = gameObject.AddComponent<HelperScript>();


    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack", false);

        touchingPlatform = helper.CheckForGround();

        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            rb.velocity = new Vector2(0, 8);
            
            isJumping=true;
        }

        if( (isJumping == true)   )
        {
            anim.SetBool("jump", true);
            if ((touchingPlatform == true) && rb.velocity.y < 1)
            {
                isJumping = false;
            }
        }
        

        //if (Input.GetKeyDown("down") && touchingPlatform)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));
          // rb.velocity = new Vector2(0, 20);
        }
        if (Input.GetKey("right"))
        {
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(2, rb.velocity.y);
            anim.SetBool("walk", true);
            helper.FlipObject(false);
        }
        if (Input.GetKey("left"))
        {
            //transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            rb.velocity = new Vector2(-2, rb.velocity.y);
            anim.SetBool("walk", true);
            helper.FlipObject(true);
        }
       
        
        if (Input.GetKey("x"))
        {
            rb.velocity = new Vector2(1, 0);
            anim.SetBool("attack", true);
        }
        if (Input.GetKey("space"))
        { 
      
            helper.FlipObject(true);    
        }
        
        int moveDirection = 1;
        if (Input.GetKeyDown("b"))
        {
            GameObject clone;
            clone = Instantiate(bird, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
        }



    }

    void OnCollisionStay2D(Collision2D collision)
    {
        print("colliding with " + collision.gameObject.tag);

        if (collision.gameObject.tag == "platform" )
        {
            //touchingPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            //touchingPlatform = false;
        }
    }


}
