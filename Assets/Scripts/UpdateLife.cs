using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class UpdateLife : MonoBehaviour {

    private Text text;
    private Player player;
    
	void Start () {
        text = GetComponent<Text>();
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        text.text = "Life: " + player.health; //update life display every frame
	}
}
