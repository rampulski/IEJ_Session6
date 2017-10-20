using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour {
    
    public Light Lampe;
    public Renderer rend;
  
 void Start() {

        
        Lampe.intensity = 0f;
        rend.material.SetColor("_MainColor", Color.black);
}
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col) // Teste la collision 
    {

        StartCoroutine("DontKillMe");




    }

    IEnumerator DontKillMe()
    {
       Lampe.intensity = 1.5f;
        rend.material.SetColor("_MainColor", Color.white);
        yield return new WaitForSeconds(10f);
        Lampe.intensity = 0f;
        rend.material.SetColor("_MainColor", Color.black);

    }




}
        
        

	
	

