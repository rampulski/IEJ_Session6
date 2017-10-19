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
    public float sphereStartIntensity;
    public float localScaleDim;
    public float localScale;




    void Start()
    {

        
        sphereLight = GetComponent<Light>();
        sphereMesh = GetComponent<MeshRenderer>();
        sphereRenderer = GetComponent<Renderer>();
        sphereFadeIn = (sphereLight.intensity / timeBeforeDestruction);
        
        sphereStartIntensity = sphereLight.intensity;

    }

    

    void Update()
    {
        float FpsParsec = (1 / Time.deltaTime);
        
        if (sphereLight.intensity != 0 || sphereLight.intensity > 0)
        {
            sphereLight.range = sphereLight.range - sphereFadeIn / FpsParsec;
            sphereLight.intensity = sphereLight.intensity - sphereFadeIn / FpsParsec;
            localScale = transform.localScale.x / 3f;
            localScaleDim = (((sphereFadeIn / FpsParsec) * (timeBeforeDestruction * 2) * localScale) * 5);
            
            if (sphereLight.intensity <= sphereStartIntensity * 0.35f)
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
