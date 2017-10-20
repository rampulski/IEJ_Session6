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
        Lampe.intensity = 0.8f;
        
        rend.material.SetColor("_MainColor", Color.white);
        
        

    }




   

}
        
        

	
	

