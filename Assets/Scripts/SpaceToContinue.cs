using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {

    public string buttonToContinue = "Jump";
    public int nextSceneBuildIndex = 1;

    private LevelManager levelManager;
    
	void Start () {
        levelManager = FindObjectOfType<LevelManager>(); //find and assign levelmanager
	}
	
	void Update () {
	    if(Input.GetButtonDown(buttonToContinue)) { //when you press "space"
            levelManager.LoadLevel(nextSceneBuildIndex);     //go to level specified
        }
	}
}