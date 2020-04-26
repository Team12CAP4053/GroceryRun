using PathCreation;
using Settingo;
using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AIPathFinding : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform waypoint;
    public PathList pathList;
    public float currentSpeed;
    private PathCreator path;
    private Vector3 position;
    private float positionTime;
    private double topSpeed;
    private CarController carController;
    private int mapScaling;
    void Start()
    {
        this.GetComponent<CarAIControl>().SetTarget(waypoint);
        carController = gameObject.GetComponent<CarController>();
        path = pathList.RandomPath();
        mapScaling = GameSetting.setting.GetScaling();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = carController.CurrentSpeed;
        position = gameObject.GetComponent<Transform>().position;
        topSpeed = carController.MaxSpeed;
        positionTime = path.path.GetClosestTimeOnPath(position);
        if(currentSpeed < 30)
        {
            waypoint.transform.position = path.path.GetPointAtTime(positionTime + (0.2f / mapScaling));
        }
        else if(currentSpeed < topSpeed * 0.6 && currentSpeed > 30)
        {
            Debug.Log(positionTime + (0.5/mapScaling) + " reee");
            waypoint.transform.position = path.path.GetPointAtTime(positionTime + (0.4f / mapScaling));
        }
        else
        {
            waypoint.transform.position = path.path.GetPointAtTime(positionTime + (0.2f / mapScaling));
        }
    }

    public void ReAssignPath()
    {
        path = pathList.RandomPath();
    }

}
