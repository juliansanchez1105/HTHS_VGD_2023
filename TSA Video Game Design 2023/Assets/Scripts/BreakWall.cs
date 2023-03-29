using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    [SerializeField] private float critVelocity = 10;
    [SerializeField] private Rigidbody2D ballBody;
    private Vector2 preVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        preVelocity = ballBody.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && preVelocity.magnitude >= critVelocity){
            //Debug.Log("BOOM");
            //ADD crash animation here
            gameObject.SetActive(false);
            ballBody.velocity = preVelocity;
        }
    }
}
