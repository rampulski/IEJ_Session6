using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{


    public GameObject Sphere;
    public Light sphereLight;

    public float timeBeforeDestruction;

    void Start()
    {

        StartCoroutine("dontKillNow");
        sphereLight = GetComponent<Light>();



    }
    IEnumerator dontKillNow()
    {

        yield return new WaitForSeconds(6);
        Destruction();



    }

    private void OnCollisionEnter(Collision collision)
    {
        sphereLight.range += 0.75f;
        sphereLight.intensity -= 0.25f;
        Debug.Log(sphereLight.intensity);
    }
    void Update()
    {
       
    }

    void Destruction()
    {        

            Destroy(gameObject);
        
    }
}
