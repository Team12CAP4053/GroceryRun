using PathCreation;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AIPathFinding : MonoBehaviour
{
    // Start is called before the first frame update
    public NextCheckpoint checkpoint;
    public Transform waypoint;
    public PathList pathList;
    public float currentSpeed;
    private PathCreator path;
    void Start()
    {
        this.GetComponent<CarAIControl>().SetTarget(waypoint);
        path = pathList.RandomPath();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = this.GetComponent<CarController>().CurrentSpeed;
        Vector3 d = gameObject.GetComponent<Transform>().position;
        
        float f = path.path.GetClosestTimeOnPath(d);
        waypoint.transform.position = path.path.GetPointAtTime(f + 0.037f); 
    }
    public void ReAssignPath()
    {
        path = pathList.RandomPath();
    }

}
