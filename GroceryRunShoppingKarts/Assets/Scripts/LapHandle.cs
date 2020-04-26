using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lastCheckpoint;
    public int maxLap = 2;
    void Start()
    {

    }
    public int GetMaxLap()
    {
        return maxLap;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KartLap>())
        {
            KartLap kart = other.GetComponent<KartLap>();
            if (kart.lapIndex == maxLap)
            {
                Debug.Log("Donezoo");
            }
            else if (kart.checkpointIndex == int.Parse(lastCheckpoint.name))
            {
                kart.incrementLap();
                kart.checkpointIndex = 1;
                if(kart.gameObject.tag == "Leonardo")
                {
                    kart.gameObject.GetComponent<AIPathFinding>().ReAssignPath();
                    Debug.Log("Changed Path");
                }
            }
        }
    }
}
