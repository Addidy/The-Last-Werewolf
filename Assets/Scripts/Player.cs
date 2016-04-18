using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 100f;     //movement speed
    public bool isAttacking { get; set; }

    public int health { get; set; }
    private Camera playerSight;
    private Voice voice;
    private Rigidbody rigidbody;
    private Animator anim;

    
	// Use this for initialization
	void Start () {
        health = 100;                                       // set initial health pool to 100
        rigidbody = GetComponent<Rigidbody>();              //get the rigidbody
        playerSight = GetComponentInChildren<Camera>();     //get eyes
        anim = GetComponent<Animator>();
        voice = GetComponentInChildren<Voice>();
    }
	
	// Update is called once per frame
	void Update () {
        CheckIfAlive();                     //Check if the player is still alive
        ControlPosition();                         //update position
        ControlCamera();                            //update where you are looking
        if(Input.GetButtonDown("Fire1")) {  //if attack key is pressed
            Attack();                       //attack
        }
    }

    private void CheckIfAlive() {
        Mathf.Clamp(health, 0, 100);
        if (health <= 0) {          //if your health reaches below 0
            Lose();                 //lose the game
        }
    }

    void Lose() {
        print("You have lose");                             //lose the game
        ScoreKeeper.win = false;                            //tell scorekeeper you lost the game
        FindObjectOfType<LevelManager>().LoadNextScene();   //load the end screen
    }

    private void Attack() {
        anim.SetTrigger("attackTrigger");
        voice.Speak(0);
    }

    private void ControlCamera() {
        float rotationSpeed = 5;                                            //multiplier for camera rotation speed
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;            //get mouse horizontal axis
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;            //get mouse vertical axis
        playerSight.transform.rotation *= Quaternion.Euler(-mouseY, 0, 0);  //change camera angle to mouse vertical axis
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);               //change body angle to mouse horizontal axis
    }

    private void ControlPosition() {
        float movementForward = Input.GetAxis("Vertical");                                              //get forward input      
        float movementStrafe = Input.GetAxis("Horizontal");                                             //get side to side input
        Vector3 desiredMove = transform.forward * movementForward + transform.right * movementStrafe;   //multiply body forward vector by forward input same for strafe (this code makes desired move on local axis and not global)
        desiredMove.x *= speed;                                                                         //multiply move directions by speed
        desiredMove.z *= speed;
        desiredMove.y *= speed;

        rigidbody.velocity = desiredMove;                                                               //assign resultant vector as your current velocity
    }
}