using UnityEngine;
using System.Collections;

public class Alert : MonoBehaviour {

    private Animator anim;
    
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    void TurnOnAlert() {
        anim.SetTrigger("alertTrigger");    //turn on yellow exclamation point to signal player the character was alerted
    }
    
	void Update () {
        State state = GetComponentInParent<Person>().currentState;
        if(state == State.ALERTED || state == State.WITNESS) {  //if host state is alerted or they witnessed the player
            TurnOnAlert();                                      //go turn on exclamation point
            Destroy(this);                                      //host cannot go back to unaware so kill this script
        }
	}
}
