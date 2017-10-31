using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit_Game : MonoBehaviour {
    public Image reset;
    public bool canQuit;
    private bool quitting;
    public float speed;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetButton("Fire2") && canQuit == true)
        {
            quitting = true;
        }
        else
        {
            quitting = false;
        }

        if (quitting == true)
        {
            reset.fillAmount += Time.deltaTime * speed;
        }
        if (reset.fillAmount > 0.95)
        {
            Debug.Log("game over");
            Application.Quit();
        }

        if (quitting == false)
        {
            reset.fillAmount = 0.0f;
        }
    }
}
