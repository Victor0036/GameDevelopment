using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{

    public float gravity = -9.8f;


    public void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.transform.up;

        //Downwards gravity to body
        body.AddForce(gravityUp * gravity);
        //Allign body to axis of planet
        body.rotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

    }
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
