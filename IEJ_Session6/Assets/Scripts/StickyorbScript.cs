using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyorbScript : MonoBehaviour {
    public Rigidbody rb;
    public SphereCollider mySphereCollider;

    void Start () {
        rb = GetComponent<Rigidbody>();
        mySphereCollider = transform.GetComponent<SphereCollider>();
    }

    void Update()
    {
    }
    void OnCollisionEnter(Collision col)
    {
        transform.parent = col.transform;
        Destroy(rb);
        Destroy(mySphereCollider);

    }
}
