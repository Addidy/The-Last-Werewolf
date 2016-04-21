using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {
    
	void Start () {
        DontDestroyOnLoad(gameObject); //don't destroy this object when loading in another scene
	}
}
