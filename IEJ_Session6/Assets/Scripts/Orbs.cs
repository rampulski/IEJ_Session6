using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

	void Start () {

        Invoke("Destruction", 3f);
	}
	
	void Update () {
		
	}

    void Destruction()
    {

        Destroy(gameObject);
    }
}
