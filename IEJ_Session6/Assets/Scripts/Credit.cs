using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour {

	public Text[] text;
	public RawImage img;



	void Start () {


		img = GetComponentInChildren<RawImage> ();
		text = GetComponentsInChildren<Text> ();

		for (int i = 0; i < text.Length; i++) {

			text [i].enabled = false;
		}

		img.enabled = false;
		StartCoroutine (Credits ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator Credits(){


		text [0].enabled = true;
		yield return new WaitForSeconds (3);
		text [0].enabled = false;
		yield return new WaitForSeconds (0.1f);

		text [1].enabled = true;
		yield return new WaitForSeconds (3);
		text [1].enabled = false;
		yield return new WaitForSeconds (0.1f);

		text [2].enabled = true;
		yield return new WaitForSeconds (3);
		text [2].enabled = false;
		yield return new WaitForSeconds (0.1f);

		text [3].enabled = true;
		img.enabled = true;
		yield return new WaitForSeconds (3);
		text [3].enabled = false;
		img.enabled = false;
		yield return new WaitForSeconds (0.1f);

        SceneManager.LoadSceneAsync("Menu");
	}
}
