using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int deathValY = -10;
    [SerializeField] private int deathValX = 30;
    [SerializeField] private Vector2 spawn = new Vector2(0, 0);
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathValY || transform.position.x >= deathValX || transform.position.x <= -1 * deathValX)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(spawn.x, spawn.y, 0);
        }
    }
}
