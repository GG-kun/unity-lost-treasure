using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coordinate : MonoBehaviour
{
    public float hoverTime;
    public StateMachine<Coordinate> stateMachine = new StateMachine<Coordinate>();
    
    public Color glow;
    public Image bulb;
    public Color off;
    public bool isGlowing;

    public Stack<State<Coordinate>> stackStates = new Stack<State<Coordinate>>();

    public void SwitchGlow() {
        isGlowing = !isGlowing;
        bulb.color = isGlowing ? glow : off;
    }

    public void StartState(State<Coordinate> initialState)
    {
        // initialize FSM
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
    }

    void Awake() {
        off = bulb.color;
        isGlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateMachine();
        if(stackStates.Count > 0 && stateMachine.CurrentState == null){
            StartState(stackStates.Pop());
        }
    }
}
