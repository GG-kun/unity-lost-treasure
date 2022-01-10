using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeState : State<Compass> 
{
    
    public override bool IsValid(Compass entity)
    {
        return true;
    }

    public override void Enter(Compass entity){
        entity.homeButton.interactable = true;
    }

    public override void Execute(Compass entity){
    }

    public override void Exit(Compass entity){
    }
}
