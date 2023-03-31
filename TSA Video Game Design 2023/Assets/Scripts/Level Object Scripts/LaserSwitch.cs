using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    //private bool laserBool;
    //[SerializeField] float delay = 3;
    // Start is called before the first frame update
    void Start()
    {
        //laserBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            //Debug.Log("VWOOM");
            laser.transform.Find("FirePoint").gameObject.SetActive(false);
            //Flip sprite to show direction of gravity
        }
        /*if(laserBool){
            Invoke("LaserOn", delay);
        }*/
    }

    public void LaserOn(){
        laser.transform.Find("FirePoint").gameObject.SetActive(true);
    }

    public void Respawn(){
        LaserOn();
    }
}
