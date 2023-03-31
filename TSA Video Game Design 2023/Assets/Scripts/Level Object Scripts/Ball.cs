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
    [SerializeField] private ParticleSystem death;
    private Vector3 spawnPoint;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        death.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = SpawnObject.transform.position;
        transform.position = spawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathValY || transform.position.x >= deathValX || transform.position.x <= -1 * deathValX)
        {
            Death();
            manager.timeStop();
        }
    }

    public void Respawn(){
        rb.velocity = new Vector3(0, 0, 0);
        transform.position = spawnPoint;
        GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(GetComponent<Rigidbody2D>().gravityScale);
        death.gameObject.SetActive(false);
    }

    public void Death(){
        death.gameObject.SetActive(true);
        death.Play();
        environ.CallRespawn();
    }

    public int DeathValX{
        get{return deathValX;}
    }

    public int DeathValY{
        get{return deathValY;}
    }
}
