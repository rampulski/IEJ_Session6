using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraseroCollider : MonoBehaviour {
	public Light Lampe;
	public Renderer rend;
	public AudioSource Source;
	public AudioClip hitOrb;
	public bool isOn;
	public BraseroListener seeScriptBraseroListener;
    
	void Start() {
		// initializations
        Lampe.intensity = 0f; // set the light intensity as off
		rend.material.SetColor("_MainColor", Color.black); // set the glass color black
		isOn = false; // say the light is off
		seeScriptBraseroListener = GameObject.Find("OrbitListener").GetComponent<BraseroListener>(); // make link with the GameManager
	}

	private void OnTriggerEnter(Collider Orbs){ // test collision  
		Illuminati (); // call what will put the light on
		isOn = true; // say the light is on
		Source.PlayOneShot(hitOrb, 1F); // play sound (I guess)
    }
		
	public void Illuminati (){ // light on
		Lampe.intensity = 1.5F; // set light intensity as on
		rend.material.SetColor("_MainColor", Color.white); // set the glass color white
		seeScriptBraseroListener.CheckArray (); // check the EndScriptGame
	}
}