using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFPS : MonoBehaviour
{
    CharacterController CC;
    Camera playerCamera;
    Transform player;
    Vector3 move = Vector3.zero;


    public int speed;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    float rotationX = 0;

    void Start()
    {
        CC = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        player = GetComponent<Transform>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }
    
    void PlayerMove()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float moveX = speed * Input.GetAxis("Vertical");
        float moveY = speed * Input.GetAxis("Horizontal");
        float movementDirectionY = move.y;
        move = forward*moveX + right*moveY;

        CC.Move(move * Time.deltaTime);
    }

    void PlayerRotate()
    {

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
