using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainCollider : MonoBehaviour {
    public ParticleSystem ps;
    public bool moduleEnabled;
    public GameObject fountain;
    
    void Start()
    {
        StopFountain();
        fountain = GameObject.FindGameObjectWithTag("fountain");
        ps = fountain.GetComponentInChildren<ParticleSystem>();

    }
    void Update()
    {
        var emission = ps.emission;
        emission.enabled = moduleEnabled;
    } 
    private void OnTriggerEnter(Collider col) 
    {
        StartCoroutine(LaunchStop());
    }
    IEnumerator LaunchStop()
    {
        PlayFountain();
        yield return new WaitForSeconds(10);
        StopFountain();
    }


    private void PlayFountain()
    {
        moduleEnabled = true;
    }
    private void StopFountain()
    {
        moduleEnabled = false;
    }




}
