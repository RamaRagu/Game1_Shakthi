using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovementHandler : MonoBehaviour
{
    public static TouchMovementHandler Instance;
    public GameObject PointerPrefab;
    public PathGenerateHandler pathHandler;

    private GameObject PointerGo;
    private Vector3 PointerPosition;
    private Plane touchPlane;
    private Camera mainCamera;
    private DynamicLine currentDynamicLine;
    public bool isAlignet = false;
    private float startingPoint_Pointer_CalcDistance;
    public float maxPointsDistance;
    public int currentNumPath, currentPathPointToHit = 0;
    public bool[] hasHitPathPoints;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }
        touchPlane = new Plane(mainCamera.transform.forward, Vector3.zero);

        currentPathPointToHit = 0;
        //hasHitPathPoints = new bool[PathGenerateHandler.Instance.myListOfPaths[0].GetComponent<PathDrawer>().path.points];


    }

    private void Update()
    {
        HandlePointer();
    }

    void HandlePointer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreatePointer();
        }
        else if (Input.GetMouseButton(0))
        {
            MovePointer();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DestroyPointer();
        }
    }

    void CreatePointer()
    {
        Ray newRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (touchPlane.Raycast(newRay, out float rayDistance))
        {
            PointerPosition = newRay.GetPoint(rayDistance);
            if (PointerPrefab != null)
            {
                PointerGo = Instantiate(PointerPrefab, PointerPosition, Quaternion.identity);
            }
            if (pathHandler != null)
            {
                pathHandler.GenerateLine();
                currentDynamicLine = pathHandler.GetLastLine();
                currentDynamicLine?.AddPoint(PointerPosition);
            }
        }
    }

    void MovePointer()
    {
        if (PointerGo == null) return;

        Ray newRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (touchPlane.Raycast(newRay, out float rayDistance))
        {
            Vector3 newPos = newRay.GetPoint(rayDistance);
            PointerGo.transform.position = newPos;
            currentDynamicLine?.AddPoint(newPos);
        }
    }

    void DestroyPointer()
    {
        if (PointerGo != null)
        {
            Destroy(PointerGo);
            PointerGo = null;
        }
    }
}