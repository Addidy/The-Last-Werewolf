using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool spawnDoor = false;
    public GameObject spawnee;
    public float rateOfSpawn = 60f;


    private float lastSpawned = 0;

    void Start() {
        lastSpawned = -rateOfSpawn; //this allows instantaneous spawn
    }

    void Update() {
        if (spawnDoor && Time.timeSinceLevelLoad >= lastSpawned + rateOfSpawn) {    //if this door spawns people and the time that has past is greater than the last time someone spawned plus the rate of spawn
            Instantiate(spawnee, transform.position, Quaternion.identity);          //spawn another person
            lastSpawned = Time.timeSinceLevelLoad;                                  //set what time the last person spawned
        }
    }


    void OnTriggerEnter(Collider col) {                                                 //when something enters the trigger
        if(col.GetComponent<Civilian>()) {                                              //if the collider is a civilian...
            Civilian civ = col.GetComponent<Civilian>();
            if (civ.currentState == State.ALERTED || civ.currentState == State.WITNESS) {//and if they are in a panicked state...
                Destroy(col.gameObject);                                                //"save" the civilian
            }
        }
    }
}
