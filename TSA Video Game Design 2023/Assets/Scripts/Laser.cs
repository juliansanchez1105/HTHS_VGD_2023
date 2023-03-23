using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject endvfx;
    // Start is called before the first frame update
    [SerializeField] private float maxLength = 100f;
    [SerializeField] private float colliderWidth = 0.2f;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLaser();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLaser(){
        lineRenderer.SetPosition(0, transform.position);

        Vector2 direction = (Vector2)transform.right;
        //Debug.Log(direction);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction, maxLength);
        //Debug.Log(hit);
        Vector2 newPoint;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        if(hit){
            newPoint = hit.point;
        }
        else{
            newPoint = new Vector2(transform.position.x + transform.right.x * maxLength, transform.position.y + transform.right.y * maxLength);
        }

        lineRenderer.SetPosition(1, newPoint);
        endvfx.transform.position = (Vector3)newPoint;
        //Debug.Log(endvfx.transform.position);
        //Debug.Log(newPoint);
        //Debug.Log(hit.collider.gameObject.name);

        float distance = Vector2.Distance((Vector2)transform.position, newPoint);
        collider.size = new Vector2(distance, colliderWidth);
        collider.offset = new Vector2(0.5f * distance, 0);
    }
}
