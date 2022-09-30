using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    //player playerScript;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // get a reference to the player's script
        //playerScript = GetComponent<player>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("enemy walk", false);
        anim.SetBool("enemy death", false);

        print("player xposition = " + player.transform.position.x);



    }
}
