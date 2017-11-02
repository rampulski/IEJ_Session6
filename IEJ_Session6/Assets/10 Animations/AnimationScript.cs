using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationScript : MonoBehaviour {
    public GameObject orb;
    public GameObject kamera;
    public GameObject titre;
    public GameObject dlight;


    private Animator animCam;
    private Animator animOrb;
    private Animator animTitre;
    private Animator animGenerallight;
    public bool launchTimer;
    private bool launch;
    public bool launchAnim;
    public float timer;
    private bool launchScene;
    public bool canQuite;
    // Use this for initialization
    void Start () {

        animOrb = orb.GetComponent<Animator>();
        animCam = kamera.GetComponent<Animator>();
        animTitre = titre.GetComponent<Animator>();
        animGenerallight = dlight.GetComponent<Animator>();
        launchTimer = false;
        launch = animCam.GetBool("LaunchEntree");
        launchAnim = false;
        timer = 0f;
        launchScene = false;
        canQuite = true;
    }
	
	// Update is called once per frame
	void Update () {
        launch = animCam.GetBool("LaunchEntree");
        if(launchTimer == true)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetButton("Fire1"))
        {
            canQuite = false;
            animCam.SetBool("LaunchEntree", true);
            animOrb.SetBool("Launch", true);
            animTitre.SetBool("Launch", true);
            animGenerallight.SetBool("Launch", true);
            launchTimer = true;
        }
        if (timer > 20f)
            {
            launchTimer = false;
            timer = 0f;
            launchScene = true;
            LaunchScene();
             }
        
        }




             void LaunchScene()
            {
                    SceneManager.LoadScene("Main"); // Il faut remplacer par "Main"
                    launchScene = false;
            }
    
        


    
}
