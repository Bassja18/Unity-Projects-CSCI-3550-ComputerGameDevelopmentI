using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health target = collision.gameObject.GetComponent<Health>();
        
        if (target != null)
        {
            target.Damage();
        }
    }
}
