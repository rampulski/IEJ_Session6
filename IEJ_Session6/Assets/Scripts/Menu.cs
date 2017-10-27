using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void Start () {
      
       
        
	}
	
	void Update () {
    if (Input.GetButtonDown("Fire1"))
    {
            Debug.Log("animation � placer"); // Faire dispara�tre le titre et lancer l'animation
        SceneManager.LoadScene("Main_Alex"); // Remplacer Main_Alex par Main
    }
	}
}
