using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    public Path path;
    private LineRenderer lineRenderer;
    public int MyCurrentNumber;
    [SerializeField] private float[] pointsDistance;


    private void Start()
    {
        GetComponent<LineRenderer>().enabled = false;
    }




    public void CreatePath()
    {
        path = new Path(transform.position);

        // Setup LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
            lineRenderer = gameObject.AddComponent<LineRenderer>();

        // Configure LineRenderer
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 0;
    }

    public void DrawPath(System.Collections.Generic.List<Vector2> points)
    {
        CacluateDistancePoints();
        if (this.GetComponent<EdgeCollider2D>() == null) return;
        {
            this.gameObject.AddComponent<EdgeCollider2D>();
        }
        this.GetComponent<EdgeCollider2D>().offset = new Vector2(0f, 0f);
        this.GetComponent<EdgeCollider2D>().points.ToArray();

        this.GetComponent<LineRenderer>().positionCount = points.Count;


        if (lineRenderer == null)
            return;

        lineRenderer.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(points[i].x, points[i].y, 0));
            this.GetComponent<EdgeCollider2D>().points[i] = new Vector2(points[i].x - 90f, points[i].y - 90f);
        }
    }

    //private void OnEnable()
    //{
    //  if (path == null)
    //{
    //  CreatePath();
    //}
    //}

    private void CacluateDistancePoints()
    {
        pointsDistance = new float[path.Points.Count - 1];
        for (int i = 0; i < pointsDistance.Length; i++)
        {
            Vector2 pointA = path.Points[i];
            Vector2 pointB = path.Points[i + 1];


            pointsDistance[i] = Vector2.Distance(pointA, pointB);
        }
    }
}

