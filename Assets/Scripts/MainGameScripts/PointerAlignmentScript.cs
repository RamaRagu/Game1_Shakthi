using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerAlignmentScript : MonoBehaviour
{
    public GameObject myMask;
    private Transform maskParent;
    private GameObject activeMask; // Track the active mask

    void Start()
    {
        maskParent = GameObject.Find("Masks")?.transform;
        if (maskParent == null)
        {
            Debug.LogError("Masks object not found in the scene!");
        }
    }

    void Update()
    {
        if (TouchMovementHandler.Instance == null) return;

        // Handle tracking only if touch or mouse is active
        if (Input.GetMouseButtonDown(0))
        {
            CreateMask();
        }
        else if (Input.GetMouseButton(0))
        {
            MoveMask();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DestroyPointer();
        }
    }

    void CreateMask()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        if (myMask != null && activeMask == null) // Prevent multiple instantiations
        {
            activeMask = Instantiate(myMask, pos, Quaternion.identity, maskParent);
        }
    }

    void MoveMask()
    {
        if (activeMask != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            activeMask.transform.position = pos;
        }
    }

    void DestroyPointer()
    {
        if (activeMask != null)
        {
            Destroy(activeMask);
            activeMask = null;
        }
    }
}