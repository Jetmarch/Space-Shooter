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

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void GetDamage(int amount = 1, bool isRewarded = true)
    {
        currentHealth -= amount;
        //Sound
        if (damageSound != null)  audioSource.PlayOneShot(damageSound);
        //Particles

        if (currentHealth <= 0)
        {
            Die(isRewarded);
        }
    }

    public void Die(bool isRewarded = true)
    {
        if(deathSound != null) AudioSource.PlayClipAtPoint(deathSound, transform.position);
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
