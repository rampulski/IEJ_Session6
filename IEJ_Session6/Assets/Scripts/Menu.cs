using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	void Start ()
    {
      
	}
	
	void Update ()
    {
    // Jouer la premi�re animation en boucle
        if (Input.GetButtonDown("Fire1"))
        {
        // Jouer la deuxi�me animation une fois
        SceneManager.LoadSceneAsync("Main_Guillaume"); // Il faut remplacer par "Main"
        }
    }
}
