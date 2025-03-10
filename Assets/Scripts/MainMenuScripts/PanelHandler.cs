using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : MonoBehaviour
{
    public string myPanelName;
    public bool PauseTheGame;

    // Update is called once per frame
    void LatestUpdate()
    {
        HandlePanelVisibility();
        HandleGamePause();
    }

    private void HandlePanelVisibility()
    {
        if (MainMenuHandler.Instance != null && MainMenuHandler.Instance.panelName != null)
        {
            if (this.myPanelName == MainMenuHandler.Instance.panelName)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                if (MainMenuHandler.Instance.panelName != "loading")
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

    private void HandleGamePause()
    {
        if (PauseTheGame)
        {
            if (this.transform.GetChild(0).gameObject.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

    }
}

