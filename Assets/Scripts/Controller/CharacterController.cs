//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharController_Motor : MonoBehaviour
//{

//    CharacterController character;
//    public GameObject cam;

//    public float speed = 10.0f;
//    public float sensitivity = 30.0f;
//    public float WaterHeight = 15.5f;
//    float gravity = -9.8f;

//    float moveFB, moveLR;
//    float rotX, rotY;
//    public bool webGLRightClickRotation = true;


//    void Start()
//    {
//        //LockCursor ();
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
//        moveFB = Input.GetAxis("Horizontal") * speed;
//        moveLR = Input.GetAxis("Vertical") * speed;

//        rotX = Input.GetAxis("Mouse X") * sensitivity;
//        rotY = Input.GetAxis("Mouse Y") * sensitivity;

//        //rotX = Input.GetKey (KeyCode.Joystick1Button4);
//        //rotY = Input.GetKey (KeyCode.Joystick1Button5);

//        CheckForWaterHeight();

//        Vector3 movement = new Vector3(moveFB, gravity, moveLR);

//        if (webGLRightClickRotation)
//        {
//            if (Input.GetKey(KeyCode.Mouse0))
//            {
//                CameraRotation(cam, rotX, rotY);
//            }
//        }
//        else if (!webGLRightClickRotation)
//        {
//            CameraRotation(cam, rotX, rotY);
//        }

//        movement = transform.rotation * movement;
//        character.Move(movement * Time.deltaTime);

//        if (Input.GetKeyDown(KeyCode.E)) { Interact(); }

//        if (Input.GetKeyDown(KeyCode.Tab)) { OpenCraftingBook(); }

//        if (Input.GetKeyDown(KeyCode.I)) { OpenInventory(); }
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



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CharController_Motor : MonoBehaviour
//{

//    CharacterController character;
//    public GameObject cam;

//    public float speed = 10.0f;
//    public float sensitivity = 30.0f;
//    public float WaterHeight = 15.5f;
//    float originalGravity = -9.8f;
//    float gravity;

//    float moveFB, moveLR;
//    float rotX, rotY;
//    public bool webGLRightClickRotation = true;

//    public float jumpStrength = 5.0f;
//    public float jumpDuration = 1.0f;
//    private bool isJumping;
//    private float jumpTimer;


//    void Start()
//    {
//        //LockCursor ();
//        character = GetComponent<CharacterController>();
//        gravity = originalGravity;

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
//            gravity = originalGravity;
//        }
//    }


//    void Update()
//    {
//        moveFB = Input.GetAxis("Horizontal") * speed;
//        moveLR = Input.GetAxis("Vertical") * speed;

//        rotX = Input.GetAxis("Mouse X") * sensitivity;
//        rotY = Input.GetAxis("Mouse Y") * sensitivity;

//        CheckForWaterHeight();

//        Vector3 movement = new Vector3(moveFB, 0, moveLR);
//        movement = transform.rotation * movement;

//        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
//        {
//            isJumping = true;
//            jumpTimer = jumpDuration;
//        }

//        if (isJumping)
//        {
//            if (jumpTimer > 0)
//            {
//                movement.y = jumpStrength;
//                jumpTimer -= Time.deltaTime;
//            }
//            else
//            {
//                isJumping = false;
//            }
//        }

//        if (!isJumping && gravity != 0f)
//        {
//            movement.y += gravity * Time.deltaTime;
//        }

//        character.Move(movement * Time.deltaTime);

//        CameraRotation(cam, rotX, rotY);

//        if (Input.GetKeyDown(KeyCode.E)) { Interact(); }
//        if (Input.GetKeyDown(KeyCode.Tab)) { OpenCraftingBook(); }
//        if (Input.GetKeyDown(KeyCode.I)) { OpenInventory(); }
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