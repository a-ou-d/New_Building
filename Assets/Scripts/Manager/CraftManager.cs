using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    public GameObject craftUIPanel;
    public GameObject craftSelectPanel;
    public GameObject helpPanel;
    public Button selectButtonPrefab;
    public MainMenu[] craftUI;

    private List<Button> craftUIButtons = new List<Button>();
    private List<Button> craftSelectButtons = new List<Button>();
    private int selectedCraftUIIndex = 0;


    public void CreateCraftUI()
    {
        craftUIPanel.SetActive(true);
        helpPanel.SetActive(true);

        foreach (var mainMenu in craftUI)
        {
            Button newButton = Instantiate(selectButtonPrefab, craftUIPanel.transform).GetComponent<Button>();
            newButton.GetComponentInChildren<Text>().text = mainMenu.menuName;
            newButton.onClick.AddListener(() => OnCraftUISelected(mainMenu));
            craftUIButtons.Add(newButton);
        }

        if (craftUIButtons.Count > 0)
        {
            UpdateButtonColor();
        }
    }


    void OnCraftUISelected(MainMenu mainMenu)
    {
        selectedCraftUIIndex = Array.IndexOf(craftUI, mainMenu);
        UpdateButtonColor();
        CreateCraftPanel(mainMenu);
    }


    void CreateCraftPanel(MainMenu mainMenu)
    {
        ClearCraftPanel();

        foreach (var subMenu in mainMenu.subMenus)
        {
            Button newButton = Instantiate(selectButtonPrefab, craftSelectPanel.transform).GetComponent<Button>();
            newButton.GetComponentInChildren<Text>().text = subMenu.subMenuName;
            newButton.onClick.AddListener(subMenu.OnSelect.Invoke);
            craftSelectButtons.Add(newButton);
        }
    }


    void ClearCraftPanel()
    {
        foreach (var button in craftSelectButtons)
        {
            Destroy(button.gameObject);
        }

        craftSelectButtons.Clear();
    }


    void UpdateButtonColor()
    {
        for (int i = 0; i < craftUIButtons.Count; i++)
        {
            craftUIButtons[i].GetComponentInChildren<Text>().color = (i == selectedCraftUIIndex) ? Color.red : Color.white;
        }
    }


    void Update()
    {
        if (!CharController_Motor.isNavigatingUI)
        {
            return;
        }

        // 메뉴 탐색 로직
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSelection(-1);
        }

        if (Input.GetKeyDown(KeyCode.E) && craftSelectButtons.Count > 0)
        {
            //
        }

        // 메뉴 닫기 로직
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (craftSelectPanel.activeSelf)
            {
                SetMenuActive(craftSelectPanel, false);
                SetMenuActive(craftUIPanel, true);
            }
            else if (craftUIPanel.activeSelf)
            {
                CloseMenus();
            }
        }
    }


    void ChangeSelection(int step)
    {
        selectedCraftUIIndex += step;

        if (selectedCraftUIIndex >= craftUIButtons.Count) selectedCraftUIIndex = 0;
        if (selectedCraftUIIndex < 0) selectedCraftUIIndex = craftUIButtons.Count - 1;

        UpdateButtonColor();
    }


    void SetMenuActive(GameObject menu, bool isActive)
    {
        menu.SetActive(isActive);
    }


    void CloseMenus()
    {
        SetMenuActive(craftUIPanel, false);
        SetMenuActive(craftSelectPanel, false);
        SetMenuActive(helpPanel, false);
    }
}
