using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minZoom = 0.5f;
    [SerializeField] private float maxZoom = 20f;
    [SerializeField] private int zoomFactor = 5;
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject pauseButton;
    private Vector3 originalMousePos;

    // Start is called before the first frame update
    void Start()
    {
        timeStop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f ) // forward
        {
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize + (zoomFactor * Input.GetAxis("Mouse ScrollWheel")), minZoom, maxZoom);
        }

        /*bool cameraMoving = false;
        if(!cameraMoving && Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 originalCameraPos = mainCamera.transform.position;
            Vector3 originalMousePos = Input.mousePosition;

            while(Input.GetKey(KeyCode.Mouse1))
            {
                mainCamera.transform.position = originalCameraPos + (originalMousePos - Input.mousePosition);
            }
        }*/

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            originalMousePos = Input.mousePosition;
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 delta = originalMousePos - Input.mousePosition;
            mainCamera.transform.Translate(delta.x * sensitivity, delta.y * sensitivity, 0);
            originalMousePos = Input.mousePosition;
        }

    }

    public void timeStop()
    {
        Time.timeScale = 0.0f;
        pauseButton.SetActive(false);
        startButton.SetActive(true);

    }

    public void timeStart()
    {
        Time.timeScale = 1.0f;
        startButton.SetActive(true);
        pauseButton.SetActive(false);
    }
}
