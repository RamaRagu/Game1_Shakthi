using UnityEngine;

public class GuideScriptHandler : MonoBehaviour
{
    public RectTransform handGuide; // Assign the hand guide sprite
    public Canvas canvas; // Assign the UI canvas (if using UI elements)

    void Update()
    {
        if (handGuide == null) return;

        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera, out mousePos);

        handGuide.anchoredPosition = mousePos; // Move the hand guide to the mouse
    }
}
