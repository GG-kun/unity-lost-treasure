using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateState : MenuState
{
    public CoordinateState(Menu entity){
        this.entity = entity;
    }

    public override bool IsValid(Menu entity)
    {
        return true;
    }

    public override void Enter(Menu entity){
        entity.SwitchShow();
    }

    public override void Execute(Menu entity){
    }

    public override void Exit(Menu entity){
        entity.SwitchShow();
    }    
}
