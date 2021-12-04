using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.MovePosition(new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y));
    }
}
