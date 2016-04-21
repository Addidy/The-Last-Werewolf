using UnityEngine;
using System.Collections;

//this component stores predetermined audioclips
//and can have the speak function accessed outside
//by other scripts to play the clips necessary
//(you will have to remember the index of the clips)

[RequireComponent (typeof(AudioSource))]
public class Voice : MonoBehaviour {

    public AudioClip[] clips;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
    public void Speak(int index) {
        audioSource.clip = clips[index];
        audioSource.Play(); 
    }
}
