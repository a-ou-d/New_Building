using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildController : MonoBehaviour
{
    public MainMenu[] mainMenuData; //메인메뉴 SO
    public GameObject buttonPrefab; //버튼 프리팹

    public Transform mainMenuContent;
    public Transform subMenuContent;

    private List<Button> mainMenuButtons = new List<Button>();
    private List<Button> subMenuButtons = new List<Button>();

    private float buttonSpacing = 30f;
    private int currentSelectedIndex = 0;


    void Start()
    {
        InitializeMainMenu();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UpdateSelection(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UpdateSelection(-1);
        }
    }


    void InitializeMainMenu()
    {
        for (int i = 0; i < mainMenuData.Length; i++)
        {
            MainMenu menu = mainMenuData[i];
            GameObject buttonObj = Instantiate(buttonPrefab, mainMenuContent);
            buttonObj.transform.localPosition = new Vector3(0, -i * buttonSpacing, 0);
            buttonObj.GetComponentInChildren<Text>().text = menu.menuName;
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => ActiveSubMenu(menu));

            mainMenuButtons.Add(button);
        }
    }


    void ActiveSubMenu(MainMenu menu)
    {
        foreach (Button btn in subMenuButtons)
        {
            Destroy(btn.gameObject);
        }

        subMenuButtons.Clear();

        for (int i = 0; i < menu.subMenus.Length; i++)
        {
            SubMenu subMenu = menu.subMenus[i];
            GameObject buttonObj = Instantiate(buttonPrefab, subMenuContent);
            buttonObj.transform.localPosition = new Vector3(0, -i * buttonSpacing, 0);
            buttonObj.GetComponentInChildren<Text>().text = subMenu.subMenuName;
            Button button = buttonObj.GetComponent<Button>();
            button.onClick.AddListener(() => Instantiate(subMenu.prefab));

            subMenuButtons.Add(button);
        }
    }


    void UpdateSelection(int direction)
    {
        currentSelectedIndex += direction;
        currentSelectedIndex = Mathf.Clamp(currentSelectedIndex, 0, mainMenuButtons.Count - 1);

        UpdateButtonVisuals();
    }


    void UpdateButtonVisuals()
    {
        if (mainMenuButtons.Count > 0)
        {
            for (int i = 0; i < mainMenuButtons.Count; i++)
            {
                ChangeButtonTextColor(mainMenuButtons[i], i == currentSelectedIndex);
            }
        }
    }


    void ChangeButtonTextColor(Button button, bool isSelected)
    {
        Text text = button.GetComponentInChildren<Text>();
        text.color = isSelected ? Color.red : new Color(0, 1, 0.071f, 1);
    }


    void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, UnityAction<BaseEventData> action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
}
