using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _ButtonHandler: MonoBehaviour
{
    public void ActivatePanel(string _panelName)
    {
        MainMenuHandler.Instance.panelName = _panelName;
    }
}
