using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakeScale(2f, 2, 5, 70, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
