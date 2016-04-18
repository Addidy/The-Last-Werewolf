using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    void OnTriggerEnter(Collider col) {         //when something enters the trigger
        if (col.GetComponent<Person>()) {       //if the collider is a civilian...
            col.GetComponent<Person>().Die();   //kill the person
        }
    }
}
