using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLoseDisplay : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if(ScoreKeeper.win) {
            text.text = "You survived... for now";
        } else {
            text.text = "You Died... there goes the last Werewolf";
        }
	}
}
