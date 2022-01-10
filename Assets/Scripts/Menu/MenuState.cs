using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuState : State<Menu>
{
    public Menu entity;
    private string id;
    private Dictionary<string, MenuState> transitions = new Dictionary<string, MenuState>();

    public void SetTransition(string key, MenuState transition) {
        this.transitions.Add(key, transition);
    }

    public MenuState GetTransition(string input) {
        MenuState transition;
        this.transitions.TryGetValue(input, out transition);
        return transition;
    }

    public string GetID() {
        return this.GetID();
    }

    public void SetID(string id) {
        this.id = id;
    }
}
