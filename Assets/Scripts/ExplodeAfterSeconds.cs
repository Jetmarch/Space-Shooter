using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAfterSeconds : MonoBehaviour
{
    [SerializeField] private float secondsToExplode;
    [SerializeField] private float explosionRadius;
    [SerializeField] private int explosionDamage;
    void Start()
    {
        StartCoroutine(TimerSet());
    }

    IEnumerator TimerSet()
    {
        yield return new WaitForSeconds(secondsToExplode);

        Boom();
    }

    void Boom()
    {
        //Create explosion effect
        Debug.Log("Boom!");

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x + explosionRadius, transform.position.y), Color.red, 2f);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x , transform.position.y + explosionRadius), Color.red, 2f);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x - explosionRadius, transform.position.y), Color.red, 2f);
        Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - explosionRadius), Color.red, 2f);
        Debug.Log(colliders.Length);
        foreach (var collider in colliders)
        {
            Health objectHealth = collider.GetComponent<Health>();
            if (objectHealth != null && !collider.CompareTag("Player"))
            {
                objectHealth.GetDamage(explosionDamage);
                Debug.Log($"{collider.name} was blowed up");
            }
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine(TimerSet());
        Boom();
    }
}
