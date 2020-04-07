using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AIPathFinding : MonoBehaviour
{
    // Start is called before the first frame update
    public NextCheckpoint checkpoint;
    GameObject Leonardo;
    void Start()
    {
        Leonardo = GameObject.FindWithTag("Leonardo");
        Leonardo.GetComponent<CarAIControl>().SetTarget(checkpoint.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Checkpoint")
        {
            checkpoint = collider.gameObject.GetComponent<NextCheckpoint>().next;
            Debug.Log(checkpoint.name);
            Leonardo.GetComponent<CarAIControl>().SetTarget(checkpoint.GetComponent<Transform>());
        }
    }
}
