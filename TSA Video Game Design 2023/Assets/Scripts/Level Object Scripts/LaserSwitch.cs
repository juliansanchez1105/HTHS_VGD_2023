using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] private List<GameObject> lasers = new List<GameObject>();
    private bool laserBool;
    [SerializeField] float delay = 3;
    private float timeSincePressed;

    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite newSprite;
    public Sprite oldSprite;

    // Start is called before the first frame update
    void Start()
    {
        laserBool = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        oldSprite = spriteRenderer.sprite;
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

    public void changeSprite(Sprite setTo){
        spriteRenderer.sprite = setTo;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            //Debug.Log("VWOOM");
            changeSprite(newSprite);
            foreach(GameObject laser in lasers){
                laser.transform.Find("FirePoint").gameObject.SetActive(false);
            }
            laserBool = false;
            timeSincePressed = 0.0f;
            //Flip sprite to show direction of gravity
        }
    }

    public void LaserOn(){
        foreach(GameObject laser in lasers){
            laser.transform.Find("FirePoint").gameObject.SetActive(true);
        }
        laserBool = true;
        changeSprite(oldSprite);
    }

    public void Respawn(){
        LaserOn();

    }
}
