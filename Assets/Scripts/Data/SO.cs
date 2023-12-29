using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MainBuild", menuName = "Menu System / Main Menu")]
public class MainMenu : ScriptableObject
{
    public string menuName;
    public SubMenu[] subMenus;
}

[CreateAssetMenu(fileName = "SubBuild", menuName = "Menu System / Sub Menu")]
public class SubMenu : ScriptableObject
{
    public string subMenuName;
    public GameObject prefab;
    public UnityEvent OnSelect;
}
