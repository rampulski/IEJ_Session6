using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{


    public GameObject Sphere;
    public MeshRenderer sphereMesh;  
    public Light sphereLight;
    public float sphereFadeIn;
    public float timeBeforeDestruction;
    public float sphereRange;
    public Material sphereMat;
    public Renderer sphereRenderer;
    public Renderer sphereRendererChildren;
    public Color sphereColor;


    void Start()
    {
        sphereLight = GetComponent<Light>();
        sphereMesh = GetComponent<MeshRenderer>();
        sphereRenderer = GetComponent<Renderer>();     
        sphereFadeIn = (sphereLight.intensity / timeBeforeDestruction);
        /*StartCoroutine("dontKillmeNowPls");*/
        //sphereColor = sphereRenderer.material.color  = Color.white;

    }

    /*IEnumerator dontKillmeNowPls()
    {               
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destruction();
    }*/

    void Update()
     {
        float FpsParsec = (1 / Time.deltaTime);

        if (sphereLight.intensity != 0 || sphereLight.intensity > 0)
        {                        
            //sphereRenderer.material.SetColor("_EmissionColor", Color.Lerp(Color.white, Color.black, Time.time / timeBeforeDestruction));
            sphereLight.range = sphereLight.range - sphereFadeIn / FpsParsec;
            sphereLight.intensity = sphereLight.intensity - sphereFadeIn / FpsParsec;       
        }
        else
        {
            Destruction();
        }

    }
   

      void Destruction()
       {
        Destroy(gameObject);
        
        }
}
