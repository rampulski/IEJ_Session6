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

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");
        launchForce = 800;
        KameraMain = Camera.main;
    }

    void Update()
    {
        Kamera = KameraMain.transform.forward;
        if (Input.GetKeyDown(KeyCode.X))
        {
            LaunchOrb();
        }
    }

    void LaunchOrb()
    {
        GameObject myOrb;
        myOrb = Instantiate(orb, player.transform.position + player.transform.forward, Quaternion.identity, orbs.transform);
        myOrb.GetComponent<Rigidbody>().AddForce(Kamera * launchForce);
    }
}
