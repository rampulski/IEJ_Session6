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
    public float localScaleDim;
    public float localScale;




    void Start()
    {
        sphereLight = GetComponent<Light>();
        sphereMesh = GetComponent<MeshRenderer>();
        sphereRenderer = GetComponent<Renderer>();     
        sphereFadeIn = (sphereLight.intensity / timeBeforeDestruction);
        /*StartCoroutine("dontKillmeNowPls");*/
      

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
            sphereLight.range = sphereLight.range - sphereFadeIn / FpsParsec;
            sphereLight.intensity = sphereLight.intensity - sphereFadeIn / FpsParsec;
            localScale = transform.localScale.x / 6f;
            localScaleDim = (((sphereFadeIn / FpsParsec)*(timeBeforeDestruction-1) * localScale)*10);
            if (sphereLight.intensity <= 1)
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale -= new Vector3(localScaleDim, localScaleDim, localScaleDim);
                }
            }
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
