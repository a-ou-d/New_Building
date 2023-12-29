using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController_Motor : MonoBehaviour
{
    public CraftManager craftManager;
    CharacterController character;
    public GameObject cam;

    public float speed = 10.0f;
    public float sensitivity = 30.0f;
    public float WaterHeight = 15.5f;
    float gravity = -9.8f;

    float moveFB, moveLR;
    float rotX, rotY;
    public bool webGLRightClickRotation = true;

    public static bool isNavigatingUI = false;


    void Start()
    {
        //LockCursor ();
        character = GetComponent<CharacterController>();

        if (Application.isEditor)
        {
            webGLRightClickRotation = false;
            sensitivity = sensitivity * 1.5f;
        }
    }


    void CheckForWaterHeight()
    {
        if (transform.position.y < WaterHeight)
        {
            gravity = 0f;
        }
        else
        {
            gravity = -9.8f;
        }
    }


    void Update()
    {
        if (!isNavigatingUI)
        {
            moveFB = Input.GetAxis("Horizontal") * speed;
            moveLR = Input.GetAxis("Vertical") * speed;

            rotX = Input.GetAxis("Mouse X") * sensitivity;
            rotY = Input.GetAxis("Mouse Y") * sensitivity;

            //rotX = Input.GetKey (KeyCode.Joystick1Button4);
            //rotY = Input.GetKey (KeyCode.Joystick1Button5);

            CheckForWaterHeight();

            Vector3 movement = new Vector3(moveFB, gravity, moveLR);

            if (webGLRightClickRotation)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    CameraRotation(cam, rotX, rotY);
                }
            }
            else if (!webGLRightClickRotation)
            {
                CameraRotation(cam, rotX, rotY);
            }

            movement = transform.rotation * movement;
            character.Move(movement * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.E)) { Interact(); }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            craftManager.CreateCraftUI();
        }
    }


    void CameraRotation(GameObject cam, float rotX, float rotY)
    {
        transform.Rotate(0, rotX * Time.deltaTime, 0);
        cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
    }


    void Interact()
    {
        // 상호작용
    }
}