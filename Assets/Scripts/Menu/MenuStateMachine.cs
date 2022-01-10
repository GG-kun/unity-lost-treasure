using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateMachine : StateMachine<Menu>
{
    private MenuState currentState;
    public void SetCurrentState(MenuState state) {
        FinishState();
        this.currentState = state;
        this.entity = state.entity;
        Begin(state);
    }

    public void Transition(string input) {
        this.SetCurrentState(this.currentState.GetTransition(input));
    }
}
