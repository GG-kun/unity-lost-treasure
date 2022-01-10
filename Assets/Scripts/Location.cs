using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string coordenates;
    static int[,] boundaries = {
        {1, 8},
        {1, 8},
    };

    public Location() {
        SetCoordenates();
    }

    public Location(string coordenates) {
        SetCoordenates(coordenates);
    }

    public static bool IsValid(string coordenates) {
        int x = -1;
        int y = -1;
        if(coordenates.Length == 2){           
            int.TryParse(coordenates[0].ToString(), out y);
            int.TryParse(coordenates[1].ToString(), out x);
            if(y >= boundaries[0,0] && y <= boundaries[0,1] &&
               x >= boundaries[1,0] && x <= boundaries[1,1]) 
            {
                return true;
            }
        }
        return false;
    }

    public void SetCoordenates(string coordenates) {
        if(IsValid(coordenates)) {
            this.coordenates = coordenates;
        }
    }

    public void SetCoordenates() {    
        int y, x;
        string coordenates = "";
        do {
            y = Random.Range(boundaries[0,0], boundaries[0,1]);
            x = Random.Range(boundaries[1,0], boundaries[1,1]);
            coordenates = y.ToString()+x.ToString();
            SetCoordenates(coordenates);
        } while(!IsValid(coordenates));
    }

    public int GetX() {
        int x = 0;
        if(this.coordenates.Length > 1){
            int.TryParse(this.coordenates[1].ToString(), out x);
        }
        return x;
    }

    public int GetY() {
        int y = 0;
        if(this.coordenates.Length > 0){
            int.TryParse(this.coordenates[0].ToString(), out y);
        }
        return y;
    }

    public Vector2 GetVector() {
        return new Vector2(this.GetX(), this.GetY());
    }

    public static float Distance(Location a, Location b) {
        return Vector2.Distance(
            a.GetVector(),
            b.GetVector()
        );
    }

    // Returns direction from location to b
    public Vector2 Direction(Location b) {
        Vector2 difference = b.GetVector() - this.GetVector();
        float x = 0;
        if(difference.x != 0) {
            x = Mathf.Sign(difference.x);
        }
        float y = 0;
        if(difference.y != 0) {
            y = Mathf.Sign(difference.y);
        }
        return new Vector2(x, y);
    }
}
