using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnRenderer : MonoBehaviour {
    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
         rend.enabled = true;
    }
}
