using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FinderTest : MonoBehaviour
{
    public PathCreator pathCreator;
    public float topspeed;
    float distanceTravelled;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.detectCollisions = true;
    }
    public void setTopSpeed(float speed)
    {
        topspeed = speed;
        Debug.Log(topspeed);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float actualtopspeed = topspeed / 2.785f;
        float speed = actualtopspeed;
        //Debug.Log(rb.velocity.magnitude);

        distanceTravelled += speed * Time.deltaTime;

        rb.MovePosition(pathCreator.path.GetPointAtDistance(distanceTravelled));
        //transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //Quaternion target = Quaternion.Euler(0,90,0);
        //Quaternion normal = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //transform.rotation = Quaternion.Slerp(normal,target,0);
        //rb.MoveRotation(Quaternion.Slerp(normal, target, 0));
        rb.MoveRotation(pathCreator.path.GetRotationAtDistance(distanceTravelled));


    }
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}