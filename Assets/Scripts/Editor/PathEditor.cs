using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathDrawer))]
public class PathEditor : Editor
{
    PathDrawer creator;
    Path path => creator.path;

    private void OnEnable()
    {
        creator = (PathDrawer)target;

        if (creator.path == null)
        {
            creator.CreatePath();
        }
    }

    private void OnSceneGUI()
    {
        HandleInput();
        DrawPoints();
    }

    private void HandleInput()
    {
        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        // Hold Shift and left click to add points
        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            Undo.RecordObject(creator, "Add Segment");
            path.AddSegment(mousePos);

            // Ensure the scene view updates
            SceneView.RepaintAll();
        }
    }

    private void DrawPoints()
    {
        // Draw the line
        creator.DrawPath(path.Points);

        // Draw the control points
        Handles.color = Color.red;
        for (int i = 0; i < path.NumPoints; i++)
        {
            var fmh_53_17_638761229959285517 = Quaternion.identity; Vector2 newPos = Handles.FreeMoveHandle(
                path[i],
                0.05f,
                Vector2.zero,
                Handles.CylinderHandleCap
            );

            if (path[i] != newPos)
            {
                Undo.RecordObject(creator, "Move Point");
                path.MovePoint(i, newPos);
            }
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.HelpBox(
            "Shift + Left Click to add points\nDrag red handles to move points",
            MessageType.Info
        );
    }
}