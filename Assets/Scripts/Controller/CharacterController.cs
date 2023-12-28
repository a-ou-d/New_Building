//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{

//    CharacterController character;
//    public GameObject cam;

//    public bool webGLRightClickRotation = true;

//    public float speed = 10.0f;
//    public float sensitivity = 30.0f;
//    public float WaterHeight = 15.5f;
//    float gravity = -9.8f;


//    void Start()
//    {
//        character = GetComponent<CharacterController>();

//        if (Application.isEditor)
//        {
//            webGLRightClickRotation = false;
//            sensitivity = sensitivity * 1.5f;
//        }
//    }


//    void CheckForWaterHeight()
//    {
//        if (transform.position.y < WaterHeight)
//        {
//            gravity = 0f;
//        }
//        else
//        {
//            gravity = -9.8f;
//        }
//    }


//    void Update()
//    {
//        float moveFB = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
//        float moveLR = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;

//        Vector3 movement = new Vector3(moveLR, 0, moveFB) * speed;
//        CheckForWaterHeight();

//        movement = transform.rotation * movement;
//        character.Move(movement * Time.deltaTime);

//        if ((webGLRightClickRotation && Input.GetKey(KeyCode.Mouse0)) || !webGLRightClickRotation)
//        {
//            float rotX = Input.GetAxis("Mouse X") * sensitivity;
//            float rotY = Input.GetAxis("Mouse Y") * sensitivity;
//            CameraRotation(cam, rotX, rotY);
//        }

//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            //Interact();
//        }

//        if (Input.GetKeyDown(KeyCode.Tab))
//        {
//            //OpenCraftingBook();
//        }

//        if (Input.GetKeyDown(KeyCode.I))
//        {
//            //OpenInventory();
//        }
//    }


//    void CameraRotation(GameObject cam, float rotX, float rotY)
//    {
//        transform.Rotate(0, rotX * Time.deltaTime, 0);
//        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
//    }


//    void Interact()
//    {
//        // 상호작용
//    }

//    void OpenCraftingBook()
//    {
//        // 건축 제작법..
//    }

//    void OpenInventory()
//    {
//        // 인벤토리
//    }
//}