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
    public float maxForceLancer;  
    public int radiusAngle;






    void Start()
    {
		
        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");
        KameraMain = Camera.main;
        timePressedKey = 0;
        launchForce = 500;
        launchObject = false;
        maxForceLancer = 1.5f ;
        radiusAngle = 45;
		orbInHand = orb;
       }

    void Update()
    {

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




		if (Input.GetKey(KeyCode.RightShift))
        {
            launchObject = true;
            timePressedKey += Time.deltaTime;
            if(timePressedKey > maxForceLancer)
            {
                timePressedKey = 1.5f;
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
        Vector3 dir = KameraMain.transform.forward; //recup la direction de la camera
        float h = dir.y; // récup la valeur de l'axe vertical
        float dist = dir.magnitude; // direction horizontal 
        float a = radiusAngle * Mathf.Deg2Rad; //Convertir angle en radian
        dir.y = dist * Mathf.Tan(a); // donne la direction pou l'angle d'élévation
        dist += h / Mathf.Tan(a); //corrige les petites diff de hauteur
        // Calcul la vélocité à appliquer à la magnitude
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        Vector3 finish = vel * dir.normalized;
        Debug.Log(finish);
        var velocityOrb = myOrb.GetComponent<Rigidbody>().velocity = finish;        
        myOrb.GetComponent<Rigidbody>().AddForce((velocityOrb * timePressedKey) * launchForce/5);
        Debug.Log((velocityOrb * timePressedKey) * launchForce/5);
    }
}
