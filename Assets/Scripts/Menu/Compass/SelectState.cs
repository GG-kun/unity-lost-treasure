using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectState : State<Compass>
{
    int coordinateIndex = 0;
    int coordinateCount;

    public override bool IsValid(Compass entity)
    {
        return true;
    }

    public override void Enter(Compass entity){
        this.time = entity.laps;
        entity.homeButton.interactable = false;
        coordinateCount = entity.coordinates.Count;
        entity.coordinates[coordinateIndex].StartState(new HoverState());
    }

    public override void Execute(Compass entity){
        int lap = coordinateIndex/coordinateCount;
        int index = coordinateIndex%coordinateCount;

        // Break
        if(lap==this.time && entity.selectedCoordinateIndex == index || lap>this.time){
            this.time = 0;
            return;
        }

        if(entity.coordinates[index].stateMachine.CurrentState == null){
            coordinateIndex++;
            index = coordinateIndex%coordinateCount;
            entity.coordinates[index].StartState(new HoverState());
        }
    }

    public override void Exit(Compass entity){
        entity.stackStates.Push(new BlinkState());
        entity.stackStates.Push(new HomeState());
    }
}
