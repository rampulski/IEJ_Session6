using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject orb;
	public GameObject orbHeavy;
	public GameObject orbLite;
	public GameObject orbBounce;
	private GameObject orbInHand; //création du contenant des orbes.
	private GameObject player;
    private GameObject orbs;
	private Time GlobalDeltaTime;
    public Camera KameraMain;
    public Vector3 Kamera;
    public int launchForce;
    public float timePressedKey;
    public bool launchObject;
    public int maxForceLancer;
    public int CoeffPuissanceTemps;
	new Vector3 ballista; 


    void Start()
    {
		
        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");
        KameraMain = Camera.main;
        timePressedKey = 0;
        launchObject = false;
        maxForceLancer = 200;
        CoeffPuissanceTemps = 15;
		orbInHand = orb; 
    }

    void Update()
    {
		if(Input.GetKey(KeyCode.Alpha1)){
			if(orbInHand != orb){

				orbInHand = orb;
			} 


		}
		if(Input.GetKey(KeyCode.Alpha2)){
			if(orbInHand != orbHeavy){

				orbInHand = orbHeavy;

			} 

		}
		if(Input.GetKey(KeyCode.Alpha3)){
			if(orbInHand != orbLite){

				orbInHand = orbLite;

			} 

		}

		if(Input.GetKey(KeyCode.Alpha4)){
			if(orbInHand != orbBounce){

				orbInHand = orbBounce;

			} 

		}




		if (Input.GetKey(KeyCode.RightShift))
        {
            launchObject = true;
            timePressedKey += Time.deltaTime;
            if(timePressedKey > maxForceLancer)
            {
                timePressedKey = 200;
            }
        }
        else if (launchObject)
        {
            LaunchOrb();
            timePressedKey = 0;
            launchObject = false; 
        }
        Kamera = KameraMain.transform.forward;
       
    }

    void LaunchOrb()
    {
        GameObject myOrb;
        myOrb = Instantiate(orbInHand, player.transform.position + player.transform.forward + player.transform.right*2, Quaternion.identity, orbs.transform);
        myOrb.GetComponent<Rigidbody>().AddForce(Kamera * launchForce * timePressedKey* CoeffPuissanceTemps);
    }
}
