using System.Collections.Generic;
using UnityEngine;

public class Path
{
    [SerializeField]
    private List<Vector2> points = new List<Vector2>();

    public Path(Vector2 startPosition)
    {
        points.Add(startPosition);
    }

    public Vector2 this[int i]
    {
        get
        {
            return points[i];
        }
    }

    public int NumPoints => points.Count;
    public List<Vector2> Points => points;

    public void AddSegment(Vector2 newPosition)
    {
        points.Add(newPosition);
    }

    public void MovePoint(int i, Vector2 newPosition)
    {
        points[i] = newPosition;
    }
}