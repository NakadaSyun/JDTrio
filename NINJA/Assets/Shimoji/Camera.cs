using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Camera cam;

    public float Sensitivity = 500f;
    float ContSensitivity = 200f;

    private bool ControllerFlg = true;

    public Transform player;

    float xRot = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        var controllerNames = Input.GetJoystickNames();
        if (controllerNames[0] == "") ControllerFlg = false;
        else ControllerFlg = true;

        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        float ContX = Input.GetAxis("R_Stick_H") * ContSensitivity * Time.deltaTime;
        float ContY = Input.GetAxis("R_Stick_V") * ContSensitivity * Time.deltaTime;

        if (!ControllerFlg) xRot -= mouseY;
        else xRot -= ContY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        player.Rotate(Vector3.up * ContX);

    }
}
