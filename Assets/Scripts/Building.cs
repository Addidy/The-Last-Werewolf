using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {



    void Start () {
        int side = Random.Range(0, 4);          //get a random number from 0 to 3 based off this number rotate the house at 90* angles
        switch (side) {
            case 1:
                transform.Rotate(0, 90f, 0);    
                break;
            case 2:
                transform.Rotate(0, 180f, 0);
                break;
            case 3:
                transform.Rotate(0, 270f, 0);
                break;
            default:
                break;
        }
	}
}
