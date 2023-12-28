using UnityEngine.UI;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject subMenu;
    public GameObject helpPanel;
    public Button[] mainMenuButtons;
    public Button[] subMenuButtons;

    private int mainMenuIndex = 0;
    private int subMenuIndex = 0;


    void Start()
    {
        //SetMenuActive(mainMenu, true);
    }


    void Update()
    {
        HandleInput();
    }


    private void HandleInput()
    {
        if (!CharController_Motor.isNavigatingUI)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelection(ref mainMenuIndex, mainMenuButtons.Length, 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSelection(ref mainMenuIndex, mainMenuButtons.Length, -1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleSubMenu(mainMenuIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (subMenu.activeSelf)
            {
                SetMenuActive(subMenu, false);
                SetMenuActive(mainMenu, true);
            }
            else if (mainMenu.activeSelf)
            {
                CloseMenus();
            }
        }
    }


    private void ChangeSelection(ref int index, int count, int step)
    {
        index = (index + step + count) % count;
        UpdateSelectionVisuals();
    }


    private void ToggleSubMenu(int index)
    {
        bool isActive = subMenuButtons[index].gameObject.activeSelf;
        SetMenuActive(subMenuButtons[index].gameObject, !isActive);

        if (!isActive)
        {
            SetMenuActive(mainMenu, false);
        }
    }


    private void UpdateSelectionVisuals()
    {
        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            var outline = mainMenuButtons[i].GetComponent<Outline>();
            outline.enabled = (i == mainMenuIndex);
        }

        for (int i = 0; i < subMenuButtons.Length; i++)
        {
            var outline = subMenuButtons[i].GetComponent<Outline>();
            outline.enabled = (i == subMenuIndex && subMenu.activeSelf);
        }
    }


    public void SetMenuActive(GameObject menu, bool isActive)
    {
        menu.SetActive(isActive);
        helpPanel.SetActive(isActive);
        CharController_Motor.isNavigatingUI = isActive;
    }


    private void CloseMenus()
    {
        SetMenuActive(mainMenu, false);
        SetMenuActive(subMenu, false);
        SetMenuActive(helpPanel, false);
    }


    public void ToggleMainMenu()
    {
        bool isActive = mainMenu.activeSelf;
        SetMenuActive(mainMenu, !isActive);
        SetMenuActive(helpPanel, !isActive);
        CharController_Motor.isNavigatingUI = !isActive;
    }
}
