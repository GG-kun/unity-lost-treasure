using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public Color color;
    public string id;
    public Location location;

    public void SetLocation() {
        this.location.SetCoordenates();
    }

    public static float Distance(Treasure a, Treasure b) {
        return Location.Distance(a.location, b.location);
    }

    private void Start() {
        this.location = new Location();
    }
}
