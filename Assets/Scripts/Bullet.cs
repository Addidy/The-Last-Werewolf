using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 5;         //bullet speed
    public int damage = 35;         //amount of damage bullet does
    private float lifeTime = 10f;   //the amount of time the bullet can remain before is despawns
    private float startTime;        //the start of the bullets life

    
	void Start () {
        startTime = Time.timeSinceLevelLoad; //set when bullet lives
	}
	
	void Update () {
	    if(Time.timeSinceLevelLoad >= (startTime + lifeTime)) { //if the bullet lives longer than designated lifetime...
            Destroy(gameObject);                                //destroy bullet
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //move bullet through the air
	}

    void OnCollisionEnter(Collision col) {                          //when the bullet hits something
        if (col.gameObject.GetComponent<Player>()) {                //if it's a player
            Player player = col.gameObject.GetComponent<Player>();  //get the player
            FindObjectOfType<HitMask>().GetHit();                   //display getting hit aesthetic
            player.health -= damage;                                //deal damage to the player
        }
        Destroy(gameObject);                                        //destroy the bullet
    }

    //void OnTriggerEnter(Collider col) {                             //when the bullet hits something
    //    if (col.gameObject.GetComponent<Player>()) {                //if it's the player
    //        FindObjectOfType<HitMask>().GetHit();                   //Flash red when you have gotten hit
    //        Player player = col.gameObject.GetComponent<Player>(); 
    //        player.health -= damage;                                //deal damage to the player
    //    }
    //    Destroy(gameObject);//destroy the bullet
    //}
}
