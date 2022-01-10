using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public float laps;
    public StateMachine<Compass> stateMachine = new StateMachine<Compass>();
    
    [SerializeField]
    // North -> 0
    // East -> 1
    // South -> 2
    // West -> 3
    public List<Coordinate> coordinates = new List<Coordinate>();
    [SerializeField]
    public Coordinate center;

    public int selectedCoordinateIndex;
    public int blinkTimes;

    public Stack<State<Compass>> stackStates = new Stack<State<Compass>>();

    public int coordinateIndex;

    public Button homeButton;

    public Coordinate GetSelectedCoordinate() {
        Coordinate selected = center;
        if(selectedCoordinateIndex < coordinates.Count){
            selected = coordinates[selectedCoordinateIndex];
        }
        return selected;
    }

    public void StartState(State<Compass> initialState)
    {
        // initialize FSM
        stateMachine.entity = this;

        stateMachine.Begin(initialState);
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
