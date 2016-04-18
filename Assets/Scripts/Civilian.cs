using UnityEngine;
using System.Collections;

public class Civilian : Person {


    public override void SwitchState(State newState) {
        base.SwitchState(newState);
        switch (newState) {
            case State.UNAWARE:
                currentAction = Action.PATROLLING;
                break;
            case State.ALERTED:
                currentAction = Action.RUNNING;
                break;
            case State.WITNESS:
                currentAction = Action.RUNNING;
                break;
            default:
                break;
        }
    }

}
