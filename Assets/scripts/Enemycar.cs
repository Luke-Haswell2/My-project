using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "projectile")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
