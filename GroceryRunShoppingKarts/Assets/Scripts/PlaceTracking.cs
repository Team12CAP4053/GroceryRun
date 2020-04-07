using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTracking : MonoBehaviour
{
    List<PlayerPosition> cars;

    void Start()
    {
        cars = new List<PlayerPosition>();
        foreach (PlayerPosition child in this.GetComponentsInChildren<PlayerPosition>())
        {
            cars.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<PlayerPosition> pos = new List<PlayerPosition>();
        for (int i = 0; i < cars.Count; i++)
        {
            
            pos.Add(cars[i]);
            if (i == 0)
            {
                continue;
            }
            else
            {
                
                for (int g = pos.Count - 1; g > 0; g--)
                {
                    
                    if (pos[g - 1].GetComponent<KartLap>().positionScore() < pos[g].GetComponent<KartLap>().positionScore())
                    {
                        
                        PlayerPosition temp = pos[g - 1];
                        pos[g - 1] = pos[g];
                        pos[g] = temp;
                    }
                    
                }
            }
        }
        for (int i = 0; i < pos.Capacity; i++)
        {
            pos[i].position = i + 1;
        }
    }
}
