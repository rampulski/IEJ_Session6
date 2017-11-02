using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {
    public GameObject ghost;
    public GameObject orb;
    public GameObject kamera;
    public GameObject titre;
    public GameObject dlight;


    private Animator animCam;
    //private Animator animGhost;
    private Animator animOrb;
    private Animator animTitre;
    private Animator animGenerallight;

    private bool launch;
    public bool launchAnim;
    public float timer;
    // Use this for initialization
    void Start () {

        /*animGhost = ghost.GetComponent<Animator>();*/
        animOrb = orb.GetComponent<Animator>();
        animCam = kamera.GetComponent<Animator>();
        animTitre = titre.GetComponent<Animator>();
        animGenerallight = dlight.GetComponent<Animator>();

        launch = animCam.GetBool("LaunchEntree");
        launchAnim = false;
        timer = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        launch = animCam.GetBool("LaunchEntree");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animCam.SetBool("LaunchEntree", true);
            //animGhost.SetBool("Launch", true);
            animOrb.SetBool("Launch", true);
            animTitre.SetBool("Launch", true);
            animGenerallight.SetBool("Launch", true);


        }
       /* if (Input.GetKeyDown(KeyCode.Space) && launch)
        {
            timer += Time.deltaTime;
            animCam.SetBool("LaunchIntro", true);
            animCam.SetBool("LaunchEntreeTitre", false);
            launchAnim = true;

            animCam.SetBool("LaunchMovingGhost", true);
            animCam.SetBool("LaunchMovingOrb", true);

           

        }*/


    }
}
