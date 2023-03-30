using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private float exitSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collider.gameObject.GetComponent<Transform>().position = transform.position;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(transform.up.x * exitSpeed, transform.up.y * exitSpeed, 0);
        }
    }
}
