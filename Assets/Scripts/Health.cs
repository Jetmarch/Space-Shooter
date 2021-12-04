using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    public bool isAlive { get; private set; }

    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private AudioClip deathSound;


    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void GetDamage(int amount = 1, bool isRewarded = true)
    {
        currentHealth -= amount;
        //Sound
        //Particles

        if (currentHealth <= 0)
        {
            Die(isRewarded);
        }
    }

    public void Die(bool isRewarded = true)
    {
        //Sound
        //Particles
        isAlive = false;
        if (isRewarded)
        {
            UIManager.instance.AddScore();
        }
        Destroy(this.gameObject);
    }
}
