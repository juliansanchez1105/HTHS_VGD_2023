using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minZoom = 0.5f;
    [SerializeField] private float maxZoom = 20f;
    [SerializeField] private int zoomFactor = 5;
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject mouseCoords;
    [SerializeField] private RectTransform canvasRect;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject levelGoal;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject StarCollected;
    [SerializeField] private GameObject StarDisplayed;
    [SerializeField] private GameObject Menu;
    [SerializeField] private int level;

    [SerializeField] private Environment environment;
    //[SerializeField] private float winScreenDelay = 3;
    private Vector2 WorldUnitsInCamera;
    private Vector2 WorldToPixelAmount;
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

        mouseCoords.GetComponent<TMP_Text>().text = string.Format("X: {0:.0}\nY: {1:.0}", (ConvertToWorldUnits(Input.mousePosition).x), ConvertToWorldUnits(Input.mousePosition).y);

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
 
 
    //Taking Your Camera Location And Is Off Setting For Position And For Amount Of World Units In Camera
    private Vector2 ConvertToWorldUnits(Vector2 TouchLocation)
    {
        Vector2 returnVec2;
        //Finding Pixel To World Unit Conversion Based On Orthographic Size Of Camera
        WorldUnitsInCamera.y = mainCamera.GetComponent<Camera>().orthographicSize * 2;
        WorldUnitsInCamera.x = WorldUnitsInCamera.y * Screen.width / Screen.height;
 
        WorldToPixelAmount.x = Screen.width / WorldUnitsInCamera.x;
        WorldToPixelAmount.y = Screen.height / WorldUnitsInCamera.y;
    
        returnVec2.x = ((TouchLocation.x / WorldToPixelAmount.x) - (WorldUnitsInCamera.x / 2)) +
        mainCamera.transform.position.x;
        returnVec2.y = ((TouchLocation.y / WorldToPixelAmount.y) - (WorldUnitsInCamera.y / 2)) +
        mainCamera.transform.position.y;
    
        return returnVec2;
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
        startButton.SetActive(false);
        pauseButton.SetActive(true);
    }


    /*public void levelWon(){
        //ANIMATION
        Invoke("levelWon2", 0.5f);

    }*/

    public void levelWon2(){
        winScreen.GetComponent<WinScreen>().OpenScreen();
        Canvas.GetComponent<ToggleVisibility>().TurnOff();
        timeStop();
        
        if(StarCollected.activeSelf == false || AccessCards.Cards[level] == true){
            StarDisplayed.SetActive(true);
            StarCollected.SetActive(false);
            Debug.Log("level: " + level);
            AccessCards.SetCardTrue(level);
            Debug.Log("AccessCards Finished");
        }
        else{
            StarDisplayed.SetActive(false);
            StarCollected.SetActive(true);
        }
    }

    public void openMenu(){
        timeStop();
        Canvas.SetActive(false);
        Menu.SetActive(true);
    }

    public void resumeFromMenu(){
        Canvas.SetActive(true);
        Menu.SetActive(false);
    }
}
