using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int deathValY = -10;
    [SerializeField] private int deathValX = 30;
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private PlayerControl manager;
    [SerializeField] private Environment environ;
    private Vector3 spawnPoint;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = SpawnObject.transform.position;
        transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathValY || transform.position.x >= deathValX || transform.position.x <= -1 * deathValX)
        {
            environ.CallRespawn();
        }
    }

    public void Respawn(){
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = spawnPoint;
        manager.timeStop();
    }
}
