using UnityEngine;
using System.Collections;

public class Sheriff : Person {

    //decision logic for sheriff

    public override void SwitchState(State newState) {
        base.SwitchState(newState);
        switch (newState) {
            case State.UNAWARE:
                currentAction = Action.STANDING;
                break;
            case State.ALERTED:
                currentAction = Action.PATROLLING;
                break;
            case State.WITNESS:
                currentAction = Action.FIGHTING;
                break;
            default:
                break;
        }
    }


    //public override void SwitchState(State newState) {
    //    base.SwitchState(newState);
    //    switch(newState) {
    //        case State.UNAWARE:
    //            currentAction = Action.STANDING;
    //            break;
    //        case State.ALERTED:
    //            currentAction = Action.PATROLLING;
    //            break;
    //        case State.WITNESS:
    //            currentAction = Action.FIGHTING;
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
