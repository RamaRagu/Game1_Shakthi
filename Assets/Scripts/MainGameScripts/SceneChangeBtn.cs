using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChangeBtn : MonoBehaviour
{
    // The name of the scene you want to load (set this in the Inspector)
    public string sceneToLoad;

    // Reference to the TextMeshPro text component on the button
    //public TextMeshProUGUI buttonText;

    // Set this to true if you want to perform panel switching (used in your second scene)
    //public bool isPanelSwitch = false;

    // The panel that should be activated (for panel switching)
    //public GameObject panelToActivate;

    // The panels that should be deactivated (for panel switching)
    //public GameObject[] panelsToDeactivate;

    // This method will be called when the button is clicked.
    public void ChangeScene()
    {
        ////if (buttonText != null)
        //{
        //    // Read the text value
        //    string textValue = buttonText.text;
        //    Debug.Log("Button text: " + textValue);
        //}
        //else
        //{
        //    Debug.LogWarning("Button text component not assigned!");
        //}

        //// Check if we should perform panel switching instead of changing scenes.
        //if (isPanelSwitch)
        //{
        //    // Activate the specified panel
        //    if (panelToActivate != null)
        //    {
        //        panelToActivate.SetActive(true);
        //        Debug.Log("Activated panel: " + panelToActivate.name);
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Panel to activate not assigned!");
        //    }

        //    // Deactivate the other panels
        //    if (panelsToDeactivate != null)
        //    {
        //        foreach (GameObject panel in panelsToDeactivate)
        //        {
        //            if (panel != null)
        //            {
        //                panel.SetActive(false);
        //                Debug.Log("Deactivated panel: " + panel.name);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Panels to deactivate not assigned!");
        //    }
        //}
        //else
        //{
            // Otherwise, change the scene as usual.
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("SceneToLoad is not set! Please assign a scene name in the Inspector.");
            }
        //}
    }
}
