using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public Camera cam;

    [SerializeField] int zoom = 20;
    [SerializeField] int normal = 60;
    [SerializeField] float Smooth = 5;

    private bool isZoomed = false;

    public Transform ParentBody;

    public float mouseSens;
    public float SlowMouseSens;
    public float StartMouseSens = 70f;
    public float MouseSensDec;
    float rotationX = 0f;

    public bool Test;

    void Start()
    {

        Test = false;

        mouseSens = StartMouseSens;
        SlowMouseSens = StartMouseSens * MouseSensDec;
        
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Test = !Test;
        }
        

        if (!Test)
        {
            ZoomInOut();
            MouseLooking();
        }
        else
        {

        }

    }

    public void MouseLooking()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        ParentBody.Rotate(Vector3.up * mouseX);
    }


    public void ZoomInOut()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime * Smooth);
            mouseSens = SlowMouseSens;
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normal, Time.deltaTime * Smooth);
            mouseSens = StartMouseSens;
        }
    }


}
