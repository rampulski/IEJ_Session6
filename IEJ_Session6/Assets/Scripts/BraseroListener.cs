using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access UI settings
using UnityEngine.SceneManagement; // access Scenes settings

public class BraseroListener : MonoBehaviour {
	// control
	public int timeBeforeFade = 5;
	public float fadeSpeed = 2F;

	// links
	public BraseroCollider[] seeScriptBraseroCollider;
	public Transform orbit;
	public GameObject sun;

	//UI
	public Image fade;
	public float time;

	//info
	public float timeTakenByFade;

	void Start () {
		// initializations
		seeScriptBraseroCollider = GameObject.FindObjectsOfType<BraseroCollider>(); // make links with all braseros collider script
		fade = GameObject.Find ("Image").GetComponent<Image> (); // make link with the UI component
		sun = GameObject.Find ("Sun"); // make link with the SunOfTheEndGame
		sun.SetActive(false); // turn this Sun off
		fade.color = new Color (0, 0, 0, 0); // set the UI as transparent
		time = Time.deltaTime; // get time in var
	}

	void Update () {
		if (CheckArray() == true){ // check the EndFonction constantly, and if it's true :
			SunCycle (); // set the Sun rotation by call
			sun.SetActive(true); // turn the Sun on
			StartCoroutine("Delay"); // put a delay beetween the Sun rise, and the fade by call
		}
		if (timeTakenByFade == 1) { // wait at the end of the fade to load the CreditScene
			SceneManager.LoadScene("Credit"); // Load the CreditsScene
		}
	}

	IEnumerator Delay (){ // delay fonction
		yield return new WaitForSeconds (timeBeforeFade); // set the delay time in seconds
		time += 0.5F * Time.deltaTime; // increment the var with time (for the FadeSpeed)
		ProgressiveBlindness (); // call the fade function
	}

	public void ProgressiveBlindness (){ // fade function
		timeTakenByFade = Mathf.Lerp(0,1,time/fadeSpeed);
		fade.color = new Color (0, 0, 0,timeTakenByFade); // set the fade with desired FadeSpeed
	}
		
	public void SunCycle (){ // Sun rotation function
		transform.Rotate (new Vector3(1*2*Time.deltaTime,0,0)); // set the rotation
	}

	public bool CheckArray (){ // EndGameChecking funcion
		for (int i = 0; i < seeScriptBraseroCollider.Length; i++) { // Check the condition below if the number "i" is inferior to the number of braseros colliders script (previously linked in initialization)
			if (seeScriptBraseroCollider[i].isOn == false) { // check the "on var" of all braseros collider script
				return false; // zero or not all "on var" braseros collider script are true, then return false (EndGameChecking function return false)
			}
		}
		return true;  // all "on var" braseros collider script are true, finish the ForWhile by returning true (EndGameChecking function return true, the game is over)
	}
}