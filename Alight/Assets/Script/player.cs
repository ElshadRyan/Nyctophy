using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
    [SerializeField] private Transform interactorSource;
    [SerializeField] private float interactorRange;
    CharacterController CC;
    Camera playerCamera;

    Vector3 move = Vector3.zero;

    float gravity = 9.8f;
    public GameObject rightHand;
    public int speed;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public bool canMove = true;

    float rotationX = 0;

    void Start()
    {
        CC = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Gravity();
        if(canMove)
        {
            PlayerMove();
            PlayerRotate();
        }
    }

    void PlayerMove()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float moveX = speed * Input.GetAxis("Vertical");
        float moveY = speed * Input.GetAxis("Horizontal");
        float movementDirectionY = move.y;
        move = forward * moveX + right * moveY;

        CC.Move(move * Time.deltaTime);
    }

    void PlayerRotate()
    {

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    void Gravity()
    {
        CC.Move(Vector3.down * gravity * Time.deltaTime);
    }
    
}
