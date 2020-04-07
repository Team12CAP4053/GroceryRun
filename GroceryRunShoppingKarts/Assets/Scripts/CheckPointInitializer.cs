using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointInitializer : MonoBehaviour
{
    private void Awake()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        List<NextCheckpoint> childObjects = new List<NextCheckpoint>();
        int idx = 1;
        foreach (Transform child in children)
        {
            if (child.gameObject.GetComponent<NextCheckpoint>())
            {
                child.name = idx + "";
                childObjects.Add(child.gameObject.GetComponent<NextCheckpoint>());
                idx++;
            }

        }
        childObjects[0].GetComponent<LapHandle>().lastCheckpoint = childObjects[childObjects.Count - 1].gameObject;
    }
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        List<NextCheckpoint> childObjects = new List<NextCheckpoint>();
        foreach (Transform child in children)
        {
            if (child.gameObject.GetComponent<NextCheckpoint>())
            {
                childObjects.Add(child.gameObject.GetComponent<NextCheckpoint>());
            }

        }
        int idx = 0;
        foreach (NextCheckpoint child in childObjects)
        {
            if (idx < childObjects.Count - 1)
            {

                child.next = childObjects[idx + 1];
            }
            else if (idx == childObjects.Count - 1)
            {
                child.next = childObjects[0];
            }
            idx++;
        }

    }
}
