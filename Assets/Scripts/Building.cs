using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int side = Random.Range(0, 4);
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
