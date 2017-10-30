using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsDestruction : MonoBehaviour
{


	private Light sphereLight;
	private Renderer sphereRenderer;
	private float localScale;   

    Vector3 localScaleValue;
    Vector3 finishScaleValue;

	private float timer;
	private float timerFadeOut;
	public float timeAlive;
	public float timeFadeOut;
	private bool fadeStart;
	public float deathSoundDuration;

    void Start()
    {
        sphereLight = GetComponent<Light>();
        sphereRenderer = GetComponent<Renderer>();
        localScale = transform.localScale.x;
		finishScaleValue = new Vector3(0, 0, 0);

    }

	void Update()
	{

		timer += Time.deltaTime;

		if (timer > timeAlive - timeFadeOut) 
		{
			fadeStart = true;
		}
		if (timer > timeAlive - deathSoundDuration) 
		{

			Destruction ();
		}


		if (fadeStart) {
			
			timerFadeOut += Time.deltaTime;

			sphereLight.intensity = Mathf.Lerp(sphereLight.intensity, 0f, timerFadeOut / timeFadeOut );
			localScaleValue = transform.localScale;
			transform.localScale = Vector3.Lerp(localScaleValue, finishScaleValue, timerFadeOut / timeFadeOut);
		}


	}

	void Destruction()
	{
		Debug.Log ("Play Destruction Sound");
		Destroy(gameObject);
	}



 //  IEnumerator FadeInLight() //CODE A FINIR 
 //   {     
 //       yield return new WaitForSeconds(lerpTime/2.5f);
 //       sphereLight.intensity = Mathf.Lerp(sphereLight.intensity, 0f, vitess);
 //   
 //   }
 //
 //   IEnumerator FadeInScale() 
 //   {
 //       yield return new WaitForSeconds(lerpTime /2.5f);
 //       localScaleValue = transform.localScale;
 //       finishScaleValue = new Vector3(0, 0, 0);
 //       transform.localScale = Vector3.Lerp(localScaleValue, finishScaleValue, vitess);
 //   }
 //   IEnumerator DestroyOrb()
 //   {
 //       yield return new WaitForSeconds(lerpTime);
 //       Destruction();
 //   }		




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
