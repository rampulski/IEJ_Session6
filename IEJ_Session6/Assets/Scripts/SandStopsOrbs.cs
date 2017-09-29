using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStopsOrbs : MonoBehaviour {
	public GameObject targetOrb;
	public PhysicMaterial noBounceMat;


	// Use this for initialization
	void Start () {
		targetOrb = GameObject.FindGameObjectWithTag ("orbs");
		noBounceMat = new PhysicMaterial ();
		noBounceMat.bounciness = 0;
		noBounceMat.dynamicFriction = 50;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "orbs"){
			other.material = noBounceMat;
		}
			
	}

}
