using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject orb;
    private GameObject player;
    private GameObject orbs;
    public Camera KameraMain;
    public Vector3 Kamera;
    public int launchForce;
    public float timePressedKey;
    public bool launchObject;
    public int maxForceLancer;
    public int CoeffPuissanceTemps;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");
        KameraMain = Camera.main;
        timePressedKey = 0;
        launchObject = false;
        maxForceLancer = 200;
        CoeffPuissanceTemps = 15;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
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
        myOrb = Instantiate(orb, player.transform.position + player.transform.forward, Quaternion.identity, orbs.transform);
        myOrb.GetComponent<Rigidbody>().AddForce(Kamera * launchForce * timePressedKey* CoeffPuissanceTemps);
    }
}
