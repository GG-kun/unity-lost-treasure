using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassState : MenuState
{
    private Compass compass;
    public CompassState(Menu entity, Compass compass){
        this.entity = entity;
        this.compass = compass;
    }

    public override bool IsValid(Menu entity)
    {
        return true;
    }

    public override void Enter(Menu entity){
        entity.SwitchShow();
        compass.StartState(new SelectState());
    }

    public override void Execute(Menu entity){
    }

    public override void Exit(Menu entity){
        entity.SwitchShow();
    }    
}
