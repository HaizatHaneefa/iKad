using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.Rotate(gameObject.transform.up, rotationSpeed);
    }
}
