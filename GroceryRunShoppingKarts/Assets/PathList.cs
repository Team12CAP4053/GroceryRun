using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathList : MonoBehaviour
{

    public List<PathCreator> paths = new List<PathCreator>();
    public List<PathCreator> availablePath = new List<PathCreator>();
    private System.Random rand;
    public void Awake()
    {
        foreach (PathCreator creator in gameObject.GetComponentsInChildren<PathCreator>())
        {
            paths.Add(creator);
            rand = new System.Random();
        }

    }
    public PathCreator RandomPath()
    {
        return paths[rand.Next() % paths.Count];
    }
    public void ResetAvailablePaths()
    {
        availablePath.Clear();
        foreach (PathCreator path in paths)
        {
            availablePath.Add(path);
        }
    }
}
