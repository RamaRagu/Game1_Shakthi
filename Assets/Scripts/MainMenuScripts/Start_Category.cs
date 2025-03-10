using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject CategoryPanel;
    public GameObject SettingsPanel;
    public GameObject AlphabetPanel;
    public GameObject ChooseItemPanel;
    public GameObject ShapesPanel;
    public GameObject NumbersPanel;
    public GameObject LinesPanel;


    public void StartButton()
    {
        MainPanel.SetActive(false);
        CategoryPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        MainPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void OpenAlphabet()
    {
        CategoryPanel.SetActive(false);
        AlphabetPanel.SetActive(true);
    }

    public void OpenShapes()
    {
        CategoryPanel.SetActive(false);
        ShapesPanel.SetActive(true);
    }

    public void OpenNumbers()
    {
        CategoryPanel.SetActive(false);
        NumbersPanel.SetActive(true);
    }

    public void OpenLines()
    {
        CategoryPanel.SetActive(false);
        LinesPanel.SetActive(true);
    }

    public void BackToStart()
    {
        CategoryPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void BackToCategory()
    {
        {
            ChooseItemPanel.SetActive(false);
            CategoryPanel.SetActive(true);
        }

    }
}
