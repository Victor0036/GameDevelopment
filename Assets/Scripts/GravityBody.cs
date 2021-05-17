using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    GravityAttractor planet;
    Rigidbody rigidbody;

    private void Awake()
    {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    private void FixedUpdate()
    {
        planet.Attract(rigidbody);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
