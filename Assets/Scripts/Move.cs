using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    [SerializeField] private Vector2 moveVector;
    private Rigidbody2D rBody;
    

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.MovePosition(new Vector2(transform.position.x + moveVector.x * speed * Time.deltaTime, transform.position.y + moveVector.y * speed * Time.deltaTime));
    }
}
