using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    public MainMenu mainMenuData; //메인메뉴 SO
    public GameObject buttonPrefab; //버튼 프리팹
    public Transform mainMenuPanel;
    public Transform subMenuPanel;

    private List<Button> mainMenuButtons = new List<Button>();
    private List<Button> subMenuButtons = new List<Button>();

    private int mainMenuIndex = 0;
    private int subMenuIndex = 0;


    void Start()
    {
        InitializeMainMenu();
    }


    void InitializeMainMenu()
    {
        foreach (var subMenu in mainMenuData.subMenus)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, mainMenuPanel);
            buttonObj.GetComponentInChildren<Text>().text = subMenu.subMenuName;
            Button button = buttonObj.GetComponent<Button>();

            button.onClick.AddListener(() => ActiveSubMenu(subMenu));

            mainMenuButtons.Add(button);
        }
    }

    void ActiveSubMenu(SubMenu subMenu)
    {
        foreach (var btn in subMenuButtons)
        {
            Destroy(btn.gameObject);
        }

        subMenuButtons.Clear();

        GameObject buttonObj = Instantiate(buttonPrefab, subMenuPanel);
        buttonObj.GetComponentInChildren<Text>().text = subMenu.subMenuName;
        Button button = buttonObj.GetComponent<Button>();

        button.onClick.AddListener(() => Instantiate(subMenu.prefab));

        subMenuButtons.Add(button);
    }
}
