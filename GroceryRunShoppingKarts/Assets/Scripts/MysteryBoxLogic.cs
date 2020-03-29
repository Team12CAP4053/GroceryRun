using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxLogic : MonoBehaviour
{

    //adjust this to change speed
    public float speed = 3f;
    //adjust this to change how high it goes
    public float height = 5f;
    // Update is called once per frame
    float rotation = 0;
    void Update()
    {

        rotation += 0.5f;
        Quaternion target = Quaternion.Euler(0, rotation, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 0.5f);
    }
}
