using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class BuildMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject subMenu;
    public GameObject helpPanel;
    public GameObject buttonPrefab;

    public List<Button> mainMenuButtons;
    private List<Button> subMenuButtons = new List<Button>();

    private float buttonSpacing = 30f;
    private int mainMenuIndex = 0;


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

        // �޴� Ž�� ����
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSelection(-1);
        }

        // ����޴� ����
        if (Input.GetKeyDown(KeyCode.E) && subMenuButtons.Count > 0)
        {
            ToggleSubMenu(mainMenuIndex);
        }

        // �޴� �ݱ� ����
        if (Input.GetKeyDown(KeyCode.Escape))
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


    public void ChangeSelection(int step)
    {
        // ���� �޴� ��ư�� �ϳ��� ���� ��� �Լ��� ����������.
        if (mainMenuButtons == null || mainMenuButtons.Count == 0)
        {
            Debug.LogWarning("No menu buttons to select.");
            return;
        }

        // �ε����� ������Ʈ�ϰ�, ������ 0�� mainMenuButtons.Count - 1 ���̷� �����Ѵ�.
        mainMenuIndex += step;
        if (mainMenuIndex >= mainMenuButtons.Count)
        {
            mainMenuIndex = 0; // ����Ʈ�� ó������ �̵�
        }
        else if (mainMenuIndex < 0)
        {
            mainMenuIndex = mainMenuButtons.Count - 1; // ����Ʈ�� ���������� �̵�
        }

        UpdateMenuSelection(mainMenuIndex);
    }


    public void ClearAndCreateSubMenuButtons(MainMenu menu, Transform subMenuContent, float buttonSpacing)
    {
        // ���� �޴� ��ư ����
        foreach (Button btn in subMenuButtons)
        {
            Destroy(btn.gameObject);
        }
        subMenuButtons.Clear();

        // ���� �޴� ��ư ����
        for (int i = 0; i < menu.subMenus.Length; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, subMenuContent);
            buttonObj.transform.localPosition = new Vector3(0, -i * buttonSpacing, 0);
            Button button = buttonObj.GetComponent<Button>();
            button.GetComponentInChildren<Text>().text = menu.subMenus[i].subMenuName;

            // UnityEvent�� ���� �����ʸ� �߰��մϴ�.
            if (menu.subMenus[i].OnSelect != null)
            {
                button.onClick.AddListener(() => menu.subMenus[i].OnSelect.Invoke());
            }
            else
            {
                Debug.LogWarning("OnSelect event is not initialized for " + menu.subMenus[i].subMenuName);
            }

            subMenuButtons.Add(button);
        }

        // UI ���� ������Ʈ
        SetMenuActive(subMenu, true);
        SetMenuActive(mainMenu, false);
    }


    private void ToggleSubMenu(int index)
    {
        if (index >= 0 && index < subMenuButtons.Count)
        {
            bool isActive = subMenuButtons[index].gameObject.activeSelf;
            SetMenuActive(subMenuButtons[index].gameObject, !isActive);

            if (!isActive)
            {
                SetMenuActive(mainMenu, false);
            }
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


    public void UpdateMenuSelection(int selectedIndex)
    {
        // ���� �޴� ��ư ���� ������Ʈ
        for (int i = 0; i < mainMenuButtons.Count; i++)
        {
            var button = mainMenuButtons[i];
            var text = button.GetComponentInChildren<Text>();
            text.color = (i == selectedIndex) ? Color.red : Color.white;
        }
    }
}
