using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController_FPS : MonoBehaviour
{
    public Camera mainCamera;

    public CharacterController characterController;
    public float moveSpeed = 2.8f;
    public bool isRunning = false;
    public Vector3 playerMoveVector = new Vector3();
    private float cameraRotateSpeed = 1f;

    private void Start()
    {
        mainCamera = Camera.main;
        characterController = gameObject.GetComponent<CharacterController>();
    }

    public void Update()
    {
        PlayerInput();
        CameraRotate();
    }

    private void FixedUpdate()
    {

        PlayerMove();
    }

    private void PlayerInput()
    {
        playerMoveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) playerMoveVector += gameObject.transform.forward;
        else isRunning = false;
        if (Input.GetKey(KeyCode.A)) playerMoveVector += -gameObject.transform.right;
        if (Input.GetKey(KeyCode.S)) playerMoveVector += -gameObject.transform.forward;
        if (Input.GetKey(KeyCode.D)) playerMoveVector += gameObject.transform.right;
        if (Input.GetKeyDown(KeyCode.LeftShift)) isRunning = isRunning == true ? false : true;
    }

    private void PlayerMove()
    {
        moveSpeed = isRunning == true ? 4.8f : 2.8f;
        characterController.SimpleMove(playerMoveVector * moveSpeed);
    }

    private void CameraRotate()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, cameraRotateSpeed * Input.GetAxis("Mouse X"));
        mainCamera.transform.RotateAround(mainCamera.transform.position, transform.right, -cameraRotateSpeed * Input.GetAxis("Mouse Y"));
    }
}
