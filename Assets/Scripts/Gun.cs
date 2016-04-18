using UnityEngine;
using System.Collections;


[RequireComponent (typeof(AudioSource))]
public class Gun : MonoBehaviour {

    public float shootRate = 3f;
    public GameObject bullet;
    public bool isAttacking { get; set; }

    private float lastShot = -100;

	// Use this for initialization
	void Start () {
        isAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {                                                     //kill yourself as well (the gun as nothing to live for)
        if (isAttacking && (lastShot + shootRate <= Time.timeSinceLevelLoad)){  //if you are alive and attacking and it's been a fire rate of time since your last shot...
            Shoot();                                                            //bust a cap
            lastShot = Time.timeSinceLevelLoad;                                 //note when you last fired your gun
        }
	}

    void Shoot () {
        Instantiate(bullet, transform.position, transform.rotation);    //create a bullet(velocity and damage coded seperately)
        GetComponent<AudioSource>().Play();
    }
}
