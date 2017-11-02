using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {
    public Image reset;
    public bool resetting = false;
    public float speed;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        if (Input.GetButton("Fire2"))
        {
            resetting = true;
        }
        else
        {
            resetting = false;
        }

        if (resetting == true)
        {
            reset.fillAmount += Time.deltaTime * speed;
        }
        if (reset.fillAmount > 0.95)
            {
                SceneManager.LoadSceneAsync("Menu");
            }

        if (resetting == false)
        {
            reset.fillAmount = 0.0f;
        }
	}
}
