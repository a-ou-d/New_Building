//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[Serializable]
//public class Build
//{
//    public string buildName;
//    public GameObject go_prefab; // 실제 설치될 프리팹
//    public GameObject go_PreviewPrefab; // 미리보기 프리팹
//}


//public class RealBuild : MonoBehaviour
//{
//    private bool isActivated = false; // BuildMenu UI 활성화 상태
//    private bool isPreviewActivated = false; // 미리보기 활성화 상태


//    [SerializeField]
//    private GameObject go_BaseUI; // 기본 베이스 UI??


//    [SerializeField]
//    private Build[] build_building;

//    private GameObject go_Preview; // 미리보기 프리팹을 담을 변수
//    private GameObject go_Prefab; // 실제 생성될 프리팹을 담을 변수


//    [SerializeField]
//    private Transform tf_Player; // 플레이어 위치

//    private RaycastHit hitInfo;


//    [SerializeField]
//    private LayerMask layerMask;


//    [SerializeField]
//    private float range;


//    public void SlotClick(int _slotNumber)
//    {
//        go_Preview = Instantiate(build_building[_slotNumber].go_PreviewPrefab, tf_Player.position + tf_Player.forward, Quaternion.identity);
//        go_Prefab = build_building[_slotNumber].go_prefab;
//        isPreviewActivated = true;
//        go_BaseUI.SetActive(false);
//    }



//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Tab) && !isPreviewActivated)
//        {
//            // ??
//        }
//        if (isPreviewActivated)
//        {
//            PreviewPositionUpdate();
//        }
//        if (Input.GetKeyDown(KeyCode.E) && isPreviewActivated)
//        {
//            Craft();
//        }
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            // BuildMenu 띄우기
//        }
//    }


//    private void PreviewPositionUpdate()
//    {
//        if (Physics.Raycast(tf_Player.position, tf_Player.forward, out hitInfo, range, layerMask))
//        {
//            if (hitInfo.transform != null)
//            {
//                Vector3 _location = hitInfo.point;

//                if (Input.GetKeyDown(KeyCode.Q))
//                {
//                    go_Preview.transform.Rotate(0f, -90f, 0f);
//                }
//                else if (Input.GetKeyDown(KeyCode.R))
//                {
//                    go_Preview.transform.Rotate(0f, +90f, 0f);
//                }

//                _location.Set(Mathf.Round(_location.x), Mathf.Round(_location.y / 0.1f) * 0.1f, Mathf.Round(_location.z));
//                go_Preview.transform.position = _location;
//            }
//        }
//    }


//    private void Craft()
//    {
//        if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().isBuildable())
//        {
//            Instantiate(go_Prefab, go_Preview.transform.position, go_Preview.transform.rotation);
//            Destroy(go_Preview);
//            isActivated = false;
//            isPreviewActivated = false;
//            go_Preview = null;
//            go_Prefab = null;
//        }
//    }
//}
