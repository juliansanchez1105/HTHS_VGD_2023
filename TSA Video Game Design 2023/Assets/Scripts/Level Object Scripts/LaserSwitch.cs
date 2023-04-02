using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private bool laserBool;
    [SerializeField] float delay = 3;
    private float timeSincePressed;
    // Start is called before the first frame update
    void Start()
    {
        laserBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!laserBool){
            timeSincePressed += Time.deltaTime;

            if(timeSincePressed >= delay){
                LaserOn();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            //Debug.Log("VWOOM");
            laser.transform.Find("FirePoint").gameObject.SetActive(false);
            laserBool = false;
            timeSincePressed = 0.0f;
            //Flip sprite to show direction of gravity
        }
    }

    public void LaserOn(){
        laser.transform.Find("FirePoint").gameObject.SetActive(true);
        laserBool = true;
    }

    public void Respawn(){
        LaserOn();

    }
}
