using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {


	public GameObject Sphere;
	public Light sphereLight;
    Collider OrbCollision;
   
    public float timeBeforeDestruction;

	void Start () {
		

		sphereLight = GetComponent<Light> ();
        sphereLight.intensity.Equals(5); 
        OrbCollision = gameObject.GetComponent(typeof(SphereCollider)) as Collider;


    }
	IEnumerator dontKillNow(){

		yield return new WaitForSeconds (10);



	}

    private void OnCollisionEnter(Collision OrbCollision)
    {
       
            sphereLight.intensity -= 1.25f;
           Debug.Log(sphereLight.intensity);
        
    }

    void Update() {
        Invoke(("Destruction"), timeBeforeDestruction);
        StartCoroutine("dontKillNow");
        
            
        
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
