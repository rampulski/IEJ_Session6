using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : MonoBehaviour {
    
        public Light Lampe;
        public Renderer rend;
        AudioSource audiosource;
        

    void Start() {

        
        Lampe.intensity = 0f;
        rend.material.SetColor("_MainColor", Color.black);
}
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Orbs) // Teste la collision 
    {
        if (Orbs)
        {
            Lampe.intensity = 1.5f;
            AkSoundEngine.PostEvent("LampadaireON", gameObject);
            rend.material.SetColor("_MainColor", Color.white);

        }


    }

  
}
        
        

	
	

