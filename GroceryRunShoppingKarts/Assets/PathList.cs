using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathList : MonoBehaviour
{

    private List<PathCreator> paths = new List<PathCreator>();
    public List<PathCreator> availablePath = new List<PathCreator>();
    private System.Random rand;
    public void Start()
    {
        foreach (PathCreator creator in gameObject.GetComponentsInChildren<PathCreator>())
        {
            paths.Add(creator);
            rand = new System.Random();
        }
    }
    public PathCreator RandomPath()
    {
        while (true)
        {
            int num = rand.Next() % paths.Count;
            if(availablePath.Count == 0)
            {
                ResetAvailablePaths();
            }
            if (availablePath.Contains(paths[num]))
            {
                availablePath.Remove(paths[num]);
                return paths[num];
            }
        }
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
