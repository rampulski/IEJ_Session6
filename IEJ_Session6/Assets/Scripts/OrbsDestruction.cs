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
}
