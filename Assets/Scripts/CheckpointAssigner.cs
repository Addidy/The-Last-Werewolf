using UnityEngine;
using System.Collections;

public class CheckpointAssigner : MonoBehaviour {
	
    public GameObject AssignCheckPoint() {
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        int result = Random.Range(0, checkPoints.Length);   //get a random checkpoint
        print(checkPoints[result]);
        return checkPoints[result];                         //return the selected random checkpoint
    }
}
