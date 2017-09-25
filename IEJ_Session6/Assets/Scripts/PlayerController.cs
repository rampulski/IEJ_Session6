using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject orb;
    private GameObject player;
    private GameObject orbs;

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        orbs = GameObject.Find("Orbs");

    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.X))
        {
            LaunchOrb();
        }

	}

    void LaunchOrb()
    {
        GameObject myOrb;
        myOrb = Instantiate(orb, player.transform.position, Quaternion.identity, orbs.transform);
        myOrb.GetComponent<Rigidbody>().AddForce(player.transform.position + player.GetComponentInChildren<Transform>().transform.forward *500);

    }
}
