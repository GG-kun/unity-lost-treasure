﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    public T entity;
    public State<T> CurrentState;
    
    //**********************************************************************************************
    public bool Begin(State<T> initialST)
    {
        if (initialST == null || !initialST.IsValid(entity))
        {
            return false;
        }
        CurrentState = initialST;
        CurrentState.Enter(entity);
        return true;
    }

    //**********************************************************************************************
    public void UpdateMachine()
    {
        if (CurrentState != null)
        {
            CurrentState.Execute(entity);
            if(CurrentState.time <= 0){
                FinishState();
            }
        }
    }

    //**********************************************************************************************
    public void FinishState()
    {
        if (CurrentState != null)
        {
            CurrentState.Exit(entity);
        }
        CurrentState = null;
    }
}
