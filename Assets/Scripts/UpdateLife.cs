using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateLife : MonoBehaviour {

    private Text text;
    private Player player;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Life: " + player.health; //update life display
	}
}
