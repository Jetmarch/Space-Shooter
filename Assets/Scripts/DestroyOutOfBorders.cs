using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorders : MonoBehaviour
{
    [SerializeField] private float maxX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(transform.position.x > maxX)
        {
            Destroy(this.gameObject);
        }
    }
}
