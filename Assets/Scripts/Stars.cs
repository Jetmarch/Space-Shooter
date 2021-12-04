using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSize;
    [SerializeField] private float minSize;

    private Move move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        
        move.speed = Random.Range(minSpeed, maxSpeed);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        transform.DOScale(Random.Range(0.5f, 1f), Random.Range(0.4f, 0.7f)).SetLoops(-1, LoopType.Yoyo);
    }

}
