using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSecondDegreePolynomial : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private float A = 1.0f;
    [SerializeField] private float B = 0.0f;
    [SerializeField] private float C = -1.0f;
    //private int length = domainEnd-domainStart;
    private float increment = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
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
        lineRenderer.positionCount = (int)((domainEnd-domainStart) * (1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = (A*x*x+B*x+C);
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

    