using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>(); //find and assign levelmanager
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Jump")) {   //when you press "space"
            levelManager.LoadLevel(1);      //go to level specified (yes I know it's hardcoded... sue me)
        }
	}
}