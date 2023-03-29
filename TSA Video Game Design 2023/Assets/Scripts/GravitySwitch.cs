using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
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
            collider.gameObject.GetComponent<Rigidbody2D>().gravityScale *= -1;
            //Flip sprite to show direction of gravity
        }
    }
}
