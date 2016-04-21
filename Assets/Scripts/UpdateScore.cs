using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScore : MonoBehaviour {

    private Text text;
    
    void Start() {
        text = GetComponent<Text>();
    }
    
    void Update() {
        text.text = "Score: " + ScoreKeeper.score.ToString();   //update score display every frame
    }
}