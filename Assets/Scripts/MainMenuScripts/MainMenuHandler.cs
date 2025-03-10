using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public static MainMenuHandler Instance;
    public Sprite[] shapeSprites, lineSprites;
    public Transform itemsContent;
    public GameObject ItemPrefab_TextBased, ItemPrefab_SpriteBased;
    [HideInInspector] public string panelName;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShowTracingItems(string category)
    {
        foreach (Transform child in itemsContent)
        {
            Destroy(child.gameObject);
        }
        switch (category)
        {
            case "alphabet":
                for (int i = 0; i < 26; i++)
                {
                    int num = i + 65;
                    SetItemText(i, num);
                }
                break;

            case "numbers":
                for (int i = 0; i < 9; i++)
                {
                    int num = i + 48;
                    SetItemText(i, num);
                }
                break;

            case "shapes":
                for (int i = 0; i < shapeSprites.Length; i++)
                {
                    SetItemImage(i, shapeSprites);
                }
                break;

            case "lines":
                for (int i = 0; i < lineSprites.Length; i++)
                {
                    SetItemImage(i, lineSprites);
                }
                break;
        }
    }

    private void SetItemText(int i, int num)
    {
        GameObject _item = Instantiate(ItemPrefab_TextBased, itemsContent);
        _item.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToChar(num).ToString();
    }

    private void SetItemImage(int i, Sprite[] spritesItem)
    {
        GameObject _item = Instantiate(ItemPrefab_SpriteBased, itemsContent);
        _item.transform.GetChild(0).GetComponent<Image>().sprite = spritesItem[i];

    }

    public void QuiteGame()
    {
        Application.Quit();
    }

}

