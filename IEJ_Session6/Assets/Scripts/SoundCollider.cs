using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour {

    public AudioSource SourceAudio;
    public AudioClip hitOrb; 

    private void OnCollisionEnter(Collision collision) // Teste la collision 
    {

        
        SourceAudio.PlayOneShot(hitOrb, 1F); //Joue le son de la collision
    }
   
}
