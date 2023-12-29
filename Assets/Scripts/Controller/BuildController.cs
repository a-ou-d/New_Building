using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    public BuildMenu buildMenu;

    public MainMenu[] mainMenuData; //메인메뉴 SO
    public GameObject buttonPrefab; //버튼 프리팹

    public Transform mainMenuContent;
    public Transform subMenuContent;

    private int currentSelectedIndex = 0;
    private bool[] subMenusInitialized;


    void Start()
    {
        InitializeMainMenu();
        buildMenu.UpdateMenuSelection(currentSelectedIndex);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSelection(-1);
        }
    }


    void InitializeMainMenu()
    {
        subMenusInitialized = new bool[mainMenuData.Length];

        for (int i = 0; i < mainMenuData.Length; i++)
        {
            MainMenu menuItem = mainMenuData[i];
            GameObject buttonObj = Instantiate(buttonPrefab, mainMenuContent);
            buttonObj.GetComponentInChildren<Text>().text = menuItem.menuName;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectMenuItem(i));
        }
    }


    void ChangeSelection(int direction)
    {
        currentSelectedIndex += direction;
        if (currentSelectedIndex >= mainMenuData.Length) currentSelectedIndex = 0;
        if (currentSelectedIndex < 0) currentSelectedIndex = mainMenuData.Length - 1;

        buildMenu.UpdateMenuSelection(currentSelectedIndex);
    }


    void SelectMenuItem(int index)
    {
        currentSelectedIndex = index;
        buildMenu.UpdateMenuSelection(index);

        if (!subMenusInitialized[index])
        {
            buildMenu.ClearAndCreateSubMenuButtons(mainMenuData[index], subMenuContent, 30f); // 서브메뉴 버튼 생성
            subMenusInitialized[index] = true;
        }
    }
}
