using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void Respawn(){
        laser.transform.Find("FirePoint").gameObject.SetActive(true);
    }
}
