using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {


	public GameObject Sphere;
	public Light sphereLight;

    public float timeBeforeDestruction;

	void Start () {
		

		sphereLight = GetComponent<Light> ();



	}
	IEnumerator dontKillNow(){

		yield return new WaitForSeconds (10);



	}


	void Update () {
		Invoke(("Destruction"),timeBeforeDestruction);
		StartCoroutine ("dontKillNow");

	}

    void Destruction()
    {
		if (sphereLight.intensity != 0) {
			sphereLight.intensity -= 0.25f; 
		} else {

			Destroy (gameObject);
		}
    }
}
