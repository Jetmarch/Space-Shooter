using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorders : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        if (collision.CompareTag("KillZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
