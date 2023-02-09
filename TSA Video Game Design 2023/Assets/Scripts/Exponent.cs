using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exponent : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private float a = 1.0f;
    [SerializeField] private float b = 20.0f; //horizontal shift
    [SerializeField] private float c = 20.0f; //vertical shift
    //[SerializeField] private int pointsPerUnit = 50;
    //private int length = domainEnd-domainStart;
    private float increment;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        increment = 0.01f;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        GenerateCollider(Draw(new Vector3(domainStart, 0.0f, 0.0f)));
    }


    List<Vector2> Draw(Vector3 startPoint)
    {
        List<Vector2> points = new List<Vector2>();
        float x = domainStart;
        float y;
        lineRenderer.positionCount = (int)((domainEnd-domainStart)*(1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = Mathf.Pow(a,(x-b))+c;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            points.Add(new Vector2(x, y));
        }
        return points;
    }

    void GenerateCollider(List<Vector2> points)
    {
        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
        collider.SetPoints(points);

    }
}

