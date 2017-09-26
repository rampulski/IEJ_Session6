using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

    public float timeBeforeDestruction;
	void Start () {

        Invoke("Destruction", timeBeforeDestruction);
	}
	
	void Update () {
		
	}

    void Destruction()
    {

        Destroy(gameObject);
    }
}
