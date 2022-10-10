using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("ground");
    }
    public void FlipObject(bool flip)
    {

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }

    void Update()
    {
        if (Input.GetKey("h"))
        {
            print("Hello World");
        }
    }
    public void DoRayCollisionCheck()
    {
        float rayLength = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask );

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
                hitColor = Color.red;
        }
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);   
    }

    public bool CheckForGround()
    {
        float rayLength = 0.5f;
        bool hitGround;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        if (hit.collider != null)
        {
            hitGround = true;
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, Color.red);
        }
        else
        {
            hitGround = false;  
        }
        return hitGround;
    }


}
