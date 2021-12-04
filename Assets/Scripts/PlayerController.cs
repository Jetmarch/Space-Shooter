using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject rocketProjectile;
    [SerializeField] private float rocketCooldown;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private bool isAlive;
    [SerializeField] private bool isRocketReady;
    
    private Rigidbody2D rBody;
    private Health health;
    private float horizontalAxis;
    private float verticalAxis;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        isAlive = true;
        isRocketReady = true;
    }

    private void Update()
    {
        if(!isAlive)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(projectile, projectileSpawn.position, transform.rotation);
        }
        if (Input.GetMouseButtonDown(1) && isRocketReady)
        {
            GameObject.Instantiate(rocketProjectile, projectileSpawn.position, transform.rotation);
            StartCoroutine(RocketCooldown());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        rBody.MovePosition(new Vector2(transform.position.x + (horizontalAxis * speed * Time.deltaTime), transform.position.y + (verticalAxis * speed * Time.deltaTime)));

        //transform.Translate(new Vector3(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            health.GetDamage();
        }
    }

    IEnumerator RocketCooldown()
    {
        isRocketReady = false;
        yield return new WaitForSeconds(rocketCooldown);
        isRocketReady = true;
    }
}
