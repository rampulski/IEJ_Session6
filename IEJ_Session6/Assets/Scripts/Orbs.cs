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
    public float fadeDuration;
    float currentLerpTime;
    float lerpTime;
    float FpsParSec;
    float FadeTime;
    Vector3 localScaleValue;
    Vector3 finishScaleValue;
    float vitess;

    void Start()
    {
        sphereLight = GetComponent<Light>();
        sphereMesh = GetComponent<MeshRenderer>();
        sphereRenderer = GetComponent<Renderer>();
        localScale = transform.localScale.x;
        sphereLight.intensity = 8;
        lerpTime = 8f;
        vitess = 0.05f;
    }

   IEnumerator FadeInLight() //CODE A FINIR 
    {     
        yield return new WaitForSeconds(lerpTime/2.5f);
        sphereLight.intensity = Mathf.Lerp(sphereLight.intensity, 0f, vitess);
    
    }

    IEnumerator FadeInScale() 
    {
        yield return new WaitForSeconds(lerpTime /2.5f);
        localScaleValue = transform.localScale;
        finishScaleValue = new Vector3(0, 0, 0);
        transform.localScale = Vector3.Lerp(localScaleValue, finishScaleValue, vitess);
    }
    IEnumerator DestroyOrb()
    {
        yield return new WaitForSeconds(lerpTime);
        Destruction();
    }

    void Update()
    {
        StartCoroutine("FadeInLight");
        StartCoroutine("FadeInScale");
        StartCoroutine("DestroyOrb");
    }


    void Destruction()
    {
        Destroy(gameObject);

    }


    /*{
        sphereLight.intensity = Mathf.Lerp(sphereLight.intensity, 0f, 1);
        Destruction();
    }
    //Debug.Log(sphereLight.intensity);

    /*
    sphereLight.intensity = Mathf.Lerp(sphereLight.intensity, 0f, Time.time);
    sphereLight.range = Mathf.Lerp(sphereLight.range, 0f, Time.time);
    */
    /*

     if (fadeSpeed !=0)
     {
         sphereLight.intensity = Mathf.Lerp(highIntensity, lowIntensity, fadeSpeed * Time.deltaTime); 
         Debug.Log(sphereLight.intensity);
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
*/




}
