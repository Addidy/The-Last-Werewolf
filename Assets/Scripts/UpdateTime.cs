using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateTime : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Time: " + Mathf.RoundToInt(FindObjectOfType<LevelManager>().timeTillNextLevel);    //update the time every frame and round that time to the nearest integer
	}
}