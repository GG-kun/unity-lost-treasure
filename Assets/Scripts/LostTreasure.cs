using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostTreasure : MonoBehaviour
{
    public float minDistance = 2;
    public List<Treasure> treasures = new List<Treasure>();

    public void RelocateTreasure(int index) {
        if(index < this.treasures.Count) {
            this.treasures[index].SetLocation();
        }
    }

    public void ValidateTreasures() {
        for (int i = 0; i < this.treasures.Count; i++)
        {
            Treasure first = treasures[i];
            for (int j = i+1; j < this.treasures.Count; j++)
            {
                Treasure second = treasures[j];
                float distance = Treasure.Distance(first, second);
                if(distance < minDistance){
                    RelocateTreasure(i);
                    i=-1;
                    break;
                }
            }
        }
    }

    void Start() {
        ValidateTreasures();
    }
}
