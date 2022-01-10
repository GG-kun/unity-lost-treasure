using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkState : State<Compass>
{
    public override bool IsValid(Compass entity)
    {
        return true;
    }

    public override void Enter(Compass entity){
        this.time = entity.blinkTimes;
    }

    public override void Execute(Compass entity){
        Coordinate selectedCoordinate = entity.GetSelectedCoordinate();
        if(selectedCoordinate.stateMachine.CurrentState == null){
            selectedCoordinate.StartState(new GlowState());
            selectedCoordinate.stackStates.Push(new GlowState());
            this.time -= 1;
        }
    }

    public override void Exit(Compass entity){
    }
}