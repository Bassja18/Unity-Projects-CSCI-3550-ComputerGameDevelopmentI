using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrel : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate to avoid some error due to different frame times
    void FixedUpdate()
    {
        // Adds velocity to the left on an update
        if (rb != null) {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        }
    }

    //Destroy barrel when it travels out of view
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Damages target when it hits something with health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health target = collision.gameObject.GetComponent<Health>();
        if (target != null)
        {
            target.Damage();
        }
    }
}
