using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {

    private Person person;
    private bool enemyInRange = false;
    private bool doorInRange = false;
    public Door door { get; set; }
    public GameObject checkpoint;


	// Use this for initialization
	void Start () {
        enemyInRange = false;                               //enemy is not in range initially by default
        person = transform.parent.GetComponent<Person>();   //get the parent component
	}

    public bool IsEnemyInRange() {
        return enemyInRange;    //if enemy in range true else false
    }

    public bool IsDoorInRange() {
        return doorInRange; //if door in range true else false
    }

    public bool IsTargetInRange() { //returns if the checkpoint is in range
        if (person.target == checkpoint)
            return true;
        else
            return false;
    }
	
    void OnTriggerEnter(Collider col) {             //if you see something
        //print(col);
        StartCoroutine(person.Found(col.gameObject));//tell person he's found an object
        if (col.tag == "Player") {                  //if it's the player                                                
            enemyInRange = true;                    //enemy is in range
        } else if (col.GetComponent<Door>()) {      //if it's the door                                       
            doorInRange = true;                     //door is in range
            door = col.GetComponent<Door>();        //save door for later retrieval
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject.tag == "Player")     //if player leaves detection radius...
            enemyInRange = false;               //enemy is no longer in range
        else if (col.gameObject == door)        //if door leaves detection raduis
            doorInRange = false;                //door is no longer in range
    }

    void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Player")     //if still detecting the player
            enemyInRange = true;   
    }
}
