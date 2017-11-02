using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit_Game : MonoBehaviour {
    public Image reset;
    public bool canQuit;
    private bool quitting;
    public float speed;
    public AnimationScript animationScript;

    void Start () {
        animationScript = GameObject.FindObjectOfType<AnimationScript>();
        canQuit = animationScript.canQuite;
    }

    void Update ()
    {
        canQuit = animationScript.canQuite;
 
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
            Application.Quit();
        }

        if (quitting == false)
        {
            reset.fillAmount = 0.0f;
        }
    }
}
