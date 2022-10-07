using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    //player playerScript;
    Rigidbody2D rb;
    HelperScript helper;
    public GameObject Enemycar;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        helper = gameObject.AddComponent<HelperScript>();

        //playerScript = GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("enemy walk", false);
        anim.SetBool("enemy death", false);

        print("player xposition = " + player.transform.position.x);

        if (player.transform.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
            anim.SetBool("enemy walk", true);
            helper.FlipObject(false);

            int moveDirection = 1;
            if (Input.GetKeyDown("n"))
            {
                GameObject clone;
                clone = Instantiate(Enemycar, transform.position, transform.rotation);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                rb.velocity = new Vector3(-15 * moveDirection, 0, 0);

                rb.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }

        }

        if (player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(1, rb.velocity.y);
            anim.SetBool("enemy walk", true);
            helper.FlipObject(true);

            int moveDirection = 1;
            if (Input.GetKeyDown("n"))
            {
                GameObject clone;
                clone = Instantiate(Enemycar, transform.position, transform.rotation);

                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                rb.velocity = new Vector3(15 * moveDirection, 0, 0);

                rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }

        }
        
    }

}
