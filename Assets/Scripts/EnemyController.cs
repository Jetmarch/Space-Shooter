using DG.Tweening;
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
            transform.DOKill();
            transform.DOShakeScale(0.3f);
        }
        if (collision.CompareTag("SuperProjectile"))
        {
            health.GetDamage(5);
        }
        if (collision.CompareTag("Player") || collision.CompareTag("Shield"))
        {
            health.Die(false);
        }

        if(collision.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }

}
