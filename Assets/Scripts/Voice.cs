using UnityEngine;
using System.Collections;

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
