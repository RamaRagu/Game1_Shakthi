using UnityEngine;

public class AlphabateButtonHandler : MonoBehaviour
{
    // Reference to the GameObject to control for the Next button.
    public GameObject nextGameObject;

    // Reference to the GameObject to control for the Previous button.
    public GameObject previousGameObject;

    // This method should be linked to the Next button's OnClick event.
    public void OnNextButtonPressed()
    {
        SwitchPanel(nextGameObject, previousGameObject);
    }

    // This method should be linked to the Previous button's OnClick event.
    public void OnPreviousButtonPressed()
    {
        SwitchPanel(previousGameObject, nextGameObject);
    }

    // Common method to handle panel switching.
    private void SwitchPanel(GameObject activateGameObject, GameObject deactivateGameObject)
    {
        if (activateGameObject != null)
        {
            activateGameObject.SetActive(true);
            Debug.Log("Activated: " + activateGameObject.name);
        }
        else
        {
            Debug.LogWarning("Activate GameObject is not assigned!");
        }

        if (deactivateGameObject != null)
        {
            deactivateGameObject.SetActive(false);
            Debug.Log("Deactivated: " + deactivateGameObject.name);
        }
        else
        {
            Debug.LogWarning("Deactivate GameObject is not assigned!");
        }
    }
}