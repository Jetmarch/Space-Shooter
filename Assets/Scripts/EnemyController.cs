using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Health health;
    private void Start()
    {
        health = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            health.GetDamage();
        }
        if (collision.CompareTag("SuperProjectile"))
        {
            Destroy(collision.gameObject);
            health.GetDamage(5);
        }
        if (collision.CompareTag("Player"))
        {
            health.Die();
        }
    }

}
