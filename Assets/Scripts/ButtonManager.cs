using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int locationDigits = 2;
    [SerializeField]
    private InputField location;

    [SerializeField]
    private Button search;

    [SerializeField]
    private Button air;
    [SerializeField]
    private Button up;
    [SerializeField]
    private Button value;
    [SerializeField]
    private Button clear;

    public MenuStateMachine stateMachine = new MenuStateMachine();
    public Menu map;
    public Menu treasure;
    public Menu coordinate;
    public Menu compassMenu;
    public Compass compass;
    public Menu home;
    public Menu returnButton;

    public FindTreasure findTreasure;
    public LostTreasure lostTreasure;

    public void FillAir() {
        findTreasure.FillAir();
        air.interactable = false;
    }

    public void EnterLocationDigit(string digit) {
        if(IsDigitValid(digit)) {
            location.text += digit;
        }
    }

    public bool IsDigitValid(string digit) {
        return location.text.Length + digit.Length <= locationDigits;
    }

    public void EraseLocationDigit() {
        int digitsLength = location.text.Length;
        if(digitsLength > 0) {
            location.text = location.text.Remove(digitsLength - 1);
        }
    }

    public bool IsLocationValid() {
        return location.text.Length == locationDigits && Location.IsValid(location.text);
    }

    public void SetLocation() {
        if(IsLocationValid()){
            findTreasure.location.SetCoordenates(location.text);
            location.text = "";
            SetTransition("Search");
        }
    }

    public void SetTreasure(int index) {
        if(index < lostTreasure.treasures.Count){
            findTreasure.treasure = lostTreasure.treasures[index];
            SetTransition("Next");
        }
    }

    public void SetAxis(int axis) {
        if(axis < 2) {
            compass.selectedCoordinateIndex = findTreasure.GetCoordinateIndex(axis);
            SetTransition("Next");
        }
    }

    public void SwitchSearch() {
        search.interactable = IsLocationValid();
    }

    public void SwitchAir() {
        air.interactable = IsLocationValid();
    }

    public void SwitchUp() {
        up.interactable = false;
    }

    public void SwitchValue() {
        value.interactable = IsLocationValid();
    }

    public void SwitchClear() {
        clear.interactable = location.text.Length > 0;
    }

    public void Previous() {
        SetTransition("Previous");
    }

    public void SetTransition(string input) {
        stateMachine.Transition(input);
    }

    void Awake() {
        MapState mapState = new MapState(map);
        mapState.SetID("Map");

        TreasureState treasureState = new TreasureState(treasure);
        treasureState.SetID("Treasure");

        CoordinateState coordinateState = new CoordinateState(coordinate);
        coordinateState.SetID("Coordinate");

        CompassState compassState = new CompassState(compassMenu, compass);
        compassState.SetID("Compass");
        
        mapState.SetTransition("Search", treasureState);

        treasureState.SetTransition("Next", coordinateState);
        treasureState.SetTransition("Previous", mapState);

        coordinateState.SetTransition("Next", compassState);
        coordinateState.SetTransition("Previous", treasureState);

        compassState.SetTransition("Home", mapState);

        stateMachine.SetCurrentState(mapState);
    }

    void Start() {
        SwitchSearch();
        SwitchAir();
        SwitchUp();
        SwitchValue();
        SwitchClear();
        location.onValueChanged.AddListener(delegate{
            SwitchSearch();
            SwitchAir();
            SwitchUp();
            SwitchValue();
            SwitchClear();
        });
    }
}
