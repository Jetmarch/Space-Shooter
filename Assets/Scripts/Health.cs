using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private AudioClip deathSound;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(int amount = 1)
    {
        currentHealth -= amount;
        //Sound
        //Particles

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Sound
        //Particles
        Destroy(this.gameObject);
    }
}
