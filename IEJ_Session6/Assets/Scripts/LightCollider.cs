using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour {
    
        public Light Lampe;
        public Renderer rend;
        public AudioSource Source;
        public AudioClip hitOrb;
    void Start() {

        
        Lampe.intensity = 0f;
        rend.material.SetColor("_MainColor", Color.black);
}
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Orbs) // Teste la collision 
    {
         
        StartCoroutine("DontKillMe");
        Source.PlayOneShot(hitOrb, 1F);



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
        
        

	
	

