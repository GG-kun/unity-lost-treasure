using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTreasure : MonoBehaviour
{
    public Location location;
    public Treasure treasure;

    const float maxAir = 100;

    public List<Coordinate> bulbs = new List<Coordinate>();
    private float air = 0;

    public void FillAir() {
        this.air = maxAir;
        GlowBulbs();
    }

    // axis = 0 -> y
    // axis = 1 -> x
    public int GetCoordinateIndex(int axis) {
        int coordinateIndex = 4; // Center is default
        Vector2 direction = this.location.Direction(this.treasure.location);
        int y = (int)direction.y;
        int x = (int)direction.x*-1;
        if(axis == 0) {
            if(y == 0){
                return coordinateIndex;
            }
            coordinateIndex = 1+y;
        } else {
            if(x == 0){
                return coordinateIndex;
            }
            coordinateIndex = 2+x;
        }
        return coordinateIndex;
    }

    private void Awake() {
        this.location = new Location();
    }

    private void GlowBulbs() {
        int glowingBulbsCount = (int)(this.air/maxAir*bulbs.Count);
        for (int i = 0; i < glowingBulbsCount; i++)
        {
            bulbs[i].StartState(new GlowState());
        }
    }
}