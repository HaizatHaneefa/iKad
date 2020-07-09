using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public Controller controller;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {
            Instantiate(controller.remains, transform.position, transform.rotation);
            Instantiate(controller.explosion, transform.position, transform.rotation);


            controller.isHit = true;
            //controller.isShake = true;

            Destroy(gameObject);
        }
    }
}
