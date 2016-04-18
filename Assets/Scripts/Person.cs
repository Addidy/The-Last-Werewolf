using UnityEngine;
using System.Collections;

public enum State { UNAWARE, ALERTED, WITNESS }
public enum Action { STANDING, PATROLLING, RUNNING, FIGHTING }

public class Person : MonoBehaviour {

    public State currentState {
        get; set;
    }
    public Action currentAction {
        get;  set;
    }

    private Gun gun;
    private Player player;
    private float stopDistance;
    private GameObject target;
    [HideInInspector]public bool alive = true;
    private Sight sight;
    private NavMeshAgent agent;
    private Voice voice;


    void Start() {
        currentState = State.UNAWARE;
        if(GetComponentInChildren<Gun>()) {                                 //if you have a gun
            gun = GetComponentInChildren<Gun>();                            //assign your gun
        }
        target = FindObjectOfType<CheckpointAssigner>().AssignCheckPoint(); //assign initial checkpoint to run to
        agent = GetComponent<NavMeshAgent>();                               //get navagent
        agent.destination = target.transform.position;                      //go to initial checkpoint
        sight = GetComponentInChildren<Sight>();
        voice = GetComponentInChildren<Voice>();//get eyes
        player = FindObjectOfType<Player>();                                //get the player
        SwitchState(currentState);                                          //get starting state
    }

	// Update is called once per frame
	void Update () {
        if (alive) {    //if still alive and you aren't just standing there...
            ContinueTask();                                 //continue doing current task
        }else if(!alive) {                                  //is if you are not alive...
            //Die();                                          //go die
        }
	}

    public void ContinueTask() {
        switch (currentAction) {    //find out what you are doing
            case Action.STANDING:
                break;
            case Action.RUNNING:    //if running
                Run();              //do what people running do
                break;
            case Action.PATROLLING: //if patrolling
                Patrol();
                break;
            case Action.FIGHTING:   //if fighting
                Fight();
                break;
            default:                //otherwise do nothing
                break;
        }
    }

    public void Die() {                     //when killed
        print("die");
        if(player.health < 100) { 
            player.health += 5;
        }
        ScoreKeeper.score++;
        //agent.destination = transform.position; //make destination current destination
        Destroy(agent);
        alive = false;                          //change status to dead
        tag = "Body";
        voice.Speak(1);
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>()) {     
            if(!(child.gameObject == gameObject || child.gameObject.GetComponent<MeshRenderer>() || child.gameObject.GetComponent<Voice>())) {//change identifier to body
                print(child);
                Destroy(child.gameObject);
            }
        }
        Destroy(agent);
        transform.rotation = Quaternion.Euler(90f, transform.localRotation.y, transform.localRotation.z);            // death animation
        Destroy(this);
    }

    public IEnumerator Found(GameObject foundEntity) {
        if (foundEntity.tag == "Player") {                                                                                          //if you find the player...
            voice.Speak(0);
            SwitchState(State.WITNESS);                                                                                             //become a witness
        } else if(foundEntity.tag == "Body" && currentState != State.WITNESS) {                                                     //if you find a dead body...
            SwitchState(State.ALERTED);                                                                                             //become alerted
        } else if(foundEntity.GetComponent<Person>()) {                                                                             //if you find another person...
            Person person = foundEntity.GetComponent<Person>();                                                                     //
            if (person.currentState == State.ALERTED || person.currentState == State.WITNESS) {                                     //if that person is startled...
                SwitchState(State.ALERTED);                                                                                         //become startled yourself
            }
        } else if (foundEntity.gameObject.tag == "CheckPoint" && currentAction == Action.PATROLLING && target == foundEntity) {     //if you find a checkpoint while patrolling...
            yield return new WaitForSeconds(4);                                                                                     //wait for 5 second
            do {                                                      
                target = FindObjectOfType<CheckpointAssigner>().AssignCheckPoint();                                                 //get a new check point
            } while (target == foundEntity);                                                                                        //make sure it's a new checkpoint
        }
    }

    public virtual void SwitchState(State newState) {
        currentState = newState;
        //change currentAction depending on state and profession
    }

    private void Run() {
        if(sight.IsDoorInRange()) {                                             //if there is a door in range
            agent.stoppingDistance = 0;                                         //don't pause before you reach your goal
            agent.destination = sight.door.gameObject.transform.position;       //run to that door and gtfo
        } else if (sight.IsEnemyInRange()) {                                    //if player in range 
            Vector3 neededVector = new Vector3();                               //initialise the an empty vector
            neededVector = transform.position - player.transform.position;      //get the difference between the player and the person
            while(neededVector.magnitude < agent.stoppingDistance) {            //if the needed vector is smaller than stopping distance...
                neededVector += neededVector;                                   //increase the difference so it is more that stopping distance
            }
            agent.destination = transform.position + neededVector;              //set sail for gtfo
        } else {                                                                //if you are running but you can't find an escape or see the creature...
            Patrol();                                                           //just run around
        }
    }

    private void Patrol() {
        if (target.tag != "CheckPoint") {                                       //if your target is not currently a checkpoint...
            target = FindObjectOfType<CheckpointAssigner>().AssignCheckPoint(); //make your target a random checkpoint
        }
            agent.destination = target.transform.position;                      //just go to your checkpoint if you are not already
    }

    private void Fight() {
        //print("fighting");
        if (sight.IsEnemyInRange()) {                       //if you see the player...
            agent.destination = player.transform.position;  //go to the player...
            transform.LookAt(player.transform);             //stare him dead in the eye...
            gun.isAttacking = true;                         //and bust a cap in his ass
        } else {                                            //if you can't see the player
            gun.isAttacking = false;                        //stop shooting idiot
            currentState = State.ALERTED;                   //stay frosty
            currentAction = Action.PATROLLING;              //start wandering around
        }
    }
}