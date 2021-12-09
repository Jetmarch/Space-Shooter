using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Main settings")]
    [SerializeField] private float speed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject rocketProjectile;
    [SerializeField] private float rocketCooldown;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private bool isRocketReady;
    [Header("Shield settings")]
    [SerializeField] private GameObject shield;
    [SerializeField] private bool isShieldActive;
    [SerializeField] private float shieldCooldown;
    [SerializeField] private float shieldUpTime;
    [SerializeField] private bool isShieldReady;

    [Header ("Sounds")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip superShootSound;
    [SerializeField] private AudioClip mainEngineSound;
    [SerializeField] private AudioClip shieldUpSound;
    [SerializeField] private AudioClip shieldDownSound;
    private AudioSource audioSource;
    private Rigidbody2D rBody;
    private Health health;
    private float horizontalAxis;
    private float verticalAxis;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        isRocketReady = true;
        shield.SetActive(false);
        isShieldActive = false;
        isShieldReady = true;
    }

    private void Update()
    {
        if(!health.isAlive || GameManager.instance.isGamePaused)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(projectile, projectileSpawn.position, transform.rotation);
            audioSource.PlayOneShot(shootSound);
        }
        if (Input.GetMouseButtonDown(1) && isRocketReady)
        {
            GameObject.Instantiate(rocketProjectile, projectileSpawn.position, transform.rotation);
            audioSource.PlayOneShot(superShootSound);
            StartCoroutine(RocketCooldown());
        }
        if(Input.GetKeyDown(KeyCode.Space) && isShieldReady)
        {
            ShieldUp();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!health.isAlive)
        {
            return;
        }
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        rBody.MovePosition(new Vector2(transform.position.x + (horizontalAxis * speed * Time.deltaTime), transform.position.y + (verticalAxis * speed * Time.deltaTime)));

        //transform.Translate(new Vector3(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f));
    }

    private void ShieldUp()
    {
        audioSource.PlayOneShot(shieldUpSound);
        StartCoroutine(ShieldWork());
        StartCoroutine(ShieldCooldown());
    }

    private IEnumerator ShieldWork()
    {
        shield.SetActive(true);
        isShieldActive = true;

        yield return new WaitForSeconds(shieldUpTime);

        isShieldActive = false;
        shield.SetActive(false);
    }

    private IEnumerator ShieldCooldown()
    {
        isShieldReady = false;

        yield return new WaitForSeconds(shieldCooldown);

        isShieldReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isShieldActive)
        {
            health.GetDamage(isRewarded: false);
            transform.DOShakeScale(0.5f);
            UIManager.instance.DamageHealth();
            if(!health.isAlive)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    IEnumerator RocketCooldown()
    {
        isRocketReady = false;
        yield return new WaitForSeconds(rocketCooldown);
        isRocketReady = true;
    }
}
