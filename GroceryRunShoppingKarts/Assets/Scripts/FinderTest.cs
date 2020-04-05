using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class FinderTest : MonoBehaviour {
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Quaternion target = Quaternion.Euler(0,90,0);
        Quaternion normal = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        transform.rotation = Quaternion.Slerp(normal,target,0);
        
    }
}
