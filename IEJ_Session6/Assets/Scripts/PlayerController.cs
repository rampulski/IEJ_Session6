using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject orb;
	public GameObject orbHeavy;
	public GameObject orbLite;
	public GameObject orbBounce;
    public GameObject orbSticky;

    private GameObject orbInHand; //création du contenant des orbes.
	private GameObject player;
    private GameObject orbs;
	private Time GlobalDeltaTime;
    public Camera KameraMain;
    public Vector3 Kamera;
    public int launchForce;
    public float timePressedKey;
    public bool launchObject;
    public float maxForceLancer;  
    public int radiusAngle;
    public Vector3 finish;
    public float HEWALKING;
    public float palier1;
    public float palier2;
    public float palier3;
    public float powerTimePressed;


    void Start()
    {		
        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");
        KameraMain = Camera.main;
        timePressedKey = 0;
        launchForce = 350;
        launchObject = false;
        maxForceLancer = 3.8f;
        powerTimePressed = 0;
        radiusAngle = 35;
		orbInHand = orb;
        HEWALKING = 1f;
        palier1 = 0.8f;
        palier2 = 1.8f;
        palier3 = 2.8f;
       }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            HEWALKING = 0.75f;         
        }
        else
        {
            HEWALKING = 1f;
        }

        if(timePressedKey <= palier1)
        {
            orbInHand = orbHeavy;
            powerTimePressed = timePressedKey * HEWALKING;
        }
        else if (timePressedKey <= palier2)
        {
            orbInHand = orbSticky;
            powerTimePressed = (timePressedKey - palier1) * HEWALKING;

        }
        else if (timePressedKey <= palier3)
        {
            orbInHand = orbBounce;
            powerTimePressed = (timePressedKey - palier2) * HEWALKING;

        }else if (timePressedKey > palier3)
        {
            orbInHand = orbBounce;
            powerTimePressed = (maxForceLancer - palier3) * HEWALKING; 
        }


            /*
            if (Input.GetKey(KeyCode.Alpha1)){
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

            */


            if (Input.GetKey(KeyCode.RightShift))
        {
            launchObject = true;
            timePressedKey += Time.deltaTime;

            if (timePressedKey > maxForceLancer)
            {
                timePressedKey = 3.75f;
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
        myOrb = Instantiate(orbInHand, player.transform.position + player.transform.forward + player.transform.right, Quaternion.identity, orbs.transform);
        Vector3 vect = KameraMain.transform.forward; //recup la direction de la camera
        AddCourb(vect);
        var velocityOrb = myOrb.GetComponent<Rigidbody>().velocity = finish;
        myOrb.GetComponent<Rigidbody>().AddForce((velocityOrb *  powerTimePressed) * launchForce); //Rajoute HEWALKING = Vitesse deplacement player

    }


    Vector3 AddCourb(Vector3 dir)
    {
        float h = dir.y; // récup la valeur de l'axe vertical
        float dist = dir.magnitude; // direction horizontal 
        float a = radiusAngle * Mathf.Deg2Rad; //Convertir angle en radian
        dir.y = dist * Mathf.Tan(a); // donne la direction pou l'angle d'élévation
        dist += h / Mathf.Tan(a); //corrige les petites diff de hauteur
        // Calcul la vélocité à appliquer à la magnitude
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        finish = vel * dir.normalized;
        return finish;
    }
}
