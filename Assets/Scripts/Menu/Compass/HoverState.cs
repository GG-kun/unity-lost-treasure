using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverState : State<Coordinate>
{
    public override bool IsValid(Coordinate entity)
    {
        return true;
    }

    public override void Enter(Coordinate entity){
        this.time = entity.hoverTime;
        entity.SwitchGlow();
    }

    public override void Execute(Coordinate entity){
        this.time -= Time.deltaTime;
    }

    public override void Exit(Coordinate entity){
        entity.SwitchGlow();
    }
}
