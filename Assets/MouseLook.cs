using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Transform ParentBody;

    public float mouseSens = 70f;
    float rotationX = 0f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        ParentBody.Rotate(Vector3.up * mouseX);
        
    }
}
