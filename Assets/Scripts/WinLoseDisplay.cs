using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLoseDisplay : MonoBehaviour {

    private Text text;

    void Start () {
        text = GetComponent<Text>();                                //get text component in currunt game object
        if(ScoreKeeper.win) {                                       //if you won the game
            text.text = "You survived... for now";                  //tell the player they lived
        } else {                                                    //else...
            text.text = "You Died... there goes the last Werewolf"; //tell the player they lost
        }
	}
}
