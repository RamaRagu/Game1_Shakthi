using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerateHandler : MonoBehaviour
{
    public GameObject LinePathPrefab;
    public Transform Spawnpoint;
    public List<GameObject> paths = new List<GameObject>();

    public void GenerateLine()
    {
        GameObject newLine = Instantiate(LinePathPrefab, Spawnpoint.position, Quaternion.identity);
        paths.Add(newLine);
    }

    public DynamicLine GetLastLine()
    {
        return paths.Count > 0 ? paths[paths.Count - 1].GetComponent<DynamicLine>() : null;
    }
}