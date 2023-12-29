//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class PreviewObject : MonoBehaviour
//{
//    public Crafting.Type needType;
//    private bool needTypeFlag;


//    private void ChangeColor()
//    {
//        if (needType == Crafting.Type.Normal)
//        {
//            if (colliderList > 0)
//            {
//                SetColor(red);
//            }
//            else
//            {
//                SetColor(green);
//            }
//        }
//        else
//        {
//            if (colliderList.Count > 0 || !needTypeFlag)
//            {
//                SetColor(red);
//            }
//            else
//            {
//                SetColor(green);
//            }
//        }
//    }


//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.transform.tag == "Structure")
//        {
//            if (other.GetComponent<Crafting>().type == needType)
//            {
//                needTypeFlag = true;
//            }
//            else
//            {
//                colliderList.Add(other);
//            }
//        }
//        else
//        {
//            if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
//            {
//                colliderList.Add(other);
//            }
//        }
//    }


//    private void OnTriggerExit(Collider other)
//    {
//        if (other.transform.tag == "Structure")
//        {
//            if (other.GetComponent<Building>().type == needType)
//            {
//                needTypeFlag = false;
//            }
//            else
//            {
//                colliderList.Remove(other);
//            }
//        }
//        else
//        {
//            if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
//            {
//                colliderList.Remove(other);
//            }
//        }
//    }


//    public bool isBuildable()
//    {
//        if (needType == Crafting.Type.Normal)
//        {
//            return colliderList.Count == 0;
//        }
//        else
//        {
//            return colliderList.Count == 0 && needTypeFlag;
//        }
//    }
//}
