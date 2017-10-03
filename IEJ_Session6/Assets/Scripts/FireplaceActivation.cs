using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceActivation : MonoBehaviour {
	private GameObject firePlace;
	// Use this for initialization
	void Start () {
	firePlace = GameObject.Find("Activator");
	firePlace.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "orbs") {
			firePlace.SetActive (true);

		}
	}
}
