using UnityEngine;
using System.Collections;

public class CheckpointAssigner : MonoBehaviour {
	
    public GameObject AssignCheckPoint() {
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint"); //find all the checkpoints in the scene
        int result = Random.Range(0, checkPoints.Length);                           //get a random checkpoint
        return checkPoints[result];                                                 //return the selected random checkpoint
    }
}