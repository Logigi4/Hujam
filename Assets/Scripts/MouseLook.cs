using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public SceneMaster Sm;

    public Animator testAnim;

    public GameMan gamman;

    public Camera cam;

    [SerializeField] int zoom = 20;
    [SerializeField] int normal = 60;
    [SerializeField] float Smooth = 5;

    public float rayRange = 4;

    private bool isZoomed = false;

    public Transform ParentBody;

    public float mouseSens;
    public float SlowMouseSens;
    public float MouseSensDec;
    float rotationX = 0f;

    public bool Test;

    void Start()
    {

        Test = false;

        mouseSens = Sensivition.Sens;
        SlowMouseSens = Sensivition.Sens * MouseSensDec;
        
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {  

          ZoomInOut();
          MouseLooking();

          CastRay();

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
            mouseSens = Sensivition.Sens;
        }
    }

    void CastRay()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, rayRange);
        if (hit)
        {
            GameObject hitObject = hitInfo.transform.gameObject;

            if (hitObject.CompareTag("Paper") || hitObject.CompareTag("Correct") || hitObject.CompareTag("Wrong") || hitObject.CompareTag("Fin") || hitObject.CompareTag("Wrong2"))
            {
                testAnim.SetBool("Look", true);
            }
            else
            {
                testAnim.SetBool("Look", false);
            }

            if (Input.GetMouseButtonDown(0) && hitObject.CompareTag("Correct"))
            {
                hitObject.GetComponentInParent<QsScript>().CorrectAnswer();
            }
            else if(Input.GetMouseButtonDown(0) && hitObject.CompareTag("Wrong"))
            {              
                hitObject.GetComponentInParent<QsScript>().WrongAnswer();
            }
            else if(Input.GetMouseButtonDown(0) && hitObject.CompareTag("Wrong2"))
            {
                hitObject.GetComponentInParent<QsScript>().WrongAnswerTwo();
            }
            else if(Input.GetMouseButtonDown(0) && hitObject.CompareTag("Fin"))
            {
                if (gamman.AbleToWin)
                {
                    ScoreCounter.QuizzNumber += 1;
                    ScoreCounter.Quizez[0] = true;
                    EndOfQuizz();
                }
                else
                {
                    EndOfQuizz();
                }
            }
        }
    }

    public void EndOfQuizz()
    {
        Sm.LoadNextScene();
    }


}
