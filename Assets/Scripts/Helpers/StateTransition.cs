using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateTransition
{
    // Identifier
    private string id;

    // Transition variables
    private Dictionary<string, StateTransition> transitions = new Dictionary<string, StateTransition>();

    public string GetID(){
        return this.id;
    }

    public void SetID(string number){
        this.id = number;
    }

    // Returns transition for given key input
    // If transition not found default transition is return
    public StateTransition GetTransition(string input) {
        StateTransition transition;
        transitions.TryGetValue(input, out transition);
        return transition;
    }

    // Set transition for given input and to given state
    public void SetTransition(string input, StateTransition transition) {
        this.transitions.Add(input, transition);
    }
}
