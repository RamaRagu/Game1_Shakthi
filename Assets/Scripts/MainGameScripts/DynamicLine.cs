using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component missing!");
        }
    }

    public void AddPoint(Vector3 point)
    {
        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], point) > 0.1f)
        {
            points.Add(point);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }
}
