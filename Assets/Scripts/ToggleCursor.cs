using UnityEngine;
using System.Collections;

public class ToggleCursor : MonoBehaviour {
	
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;   //lock cursor when game starts
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))                //if you click...
            Cursor.lockState = CursorLockMode.Locked;   //lock your cursor
        if (Input.GetKeyDown(KeyCode.Escape)) {         //if you hit escape
            Cursor.lockState = CursorLockMode.None;     //unlock your cursor (this script is somewhat dodgy and broken)
            Cursor.visible = true;                      //make your cursor visible
        }
    }
}
