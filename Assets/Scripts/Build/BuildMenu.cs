using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject[] mainMenus;
    public GameObject subMenu;
    public GameObject[] subMenus;
    private int mainMenuIndex = 0;
    private int subMenuIndex = 0;
    private bool isSubMenuActive = false;


    void Update()
    {
        if (!isSubMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mainMenuIndex = Mathf.Min(mainMenuIndex + 1, mainMenus.Length - 1);
                UpdateMainMenuSelection();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mainMenuIndex = Mathf.Max(mainMenuIndex - 1, 0);
                UpdateMainMenuSelection();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ActiveSubMenu(mainMenuIndex);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mainMenuIndex = Mathf.Min(mainMenuIndex + 1, mainMenus.Length - 1);
                UpdateSubMenuSelection();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mainMenuIndex = Mathf.Max(mainMenuIndex - 1, 0);
                UpdateSubMenuSelection();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                // ÇÁ¸®ºä ¶ç¿ï°Å
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSubMenuActive)
            {
                CloseSubMenu();
            }
            else
            {
                CloseBuildMenu();
            }
        }
    }


    void ActiveSubMenu(int index)
    {
        CloseSubMenu();

        subMenus[index].SetActive(true);
        isSubMenuActive = true;

        CharController_Motor.isNavigatingUI = true;
    }

    void CloseSubMenu()
    {
        foreach (var submenu in subMenus)
        {
            submenu.SetActive(false);
        }

        isSubMenuActive = false;

        CharController_Motor.isNavigatingUI = false;
    }

    void UpdateMainMenuSelection()
    {
        mainMenus[mainMenuIndex].GetComponent<Button>().Select();
    }

    void UpdateSubMenuSelection()
    {
        subMenus[subMenuIndex].GetComponent<Button>().Select();
    }

    void CloseBuildMenu()
    {
        mainMenu.SetActive(false);
        CloseSubMenu();
    }
}
