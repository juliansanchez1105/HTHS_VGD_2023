using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawThirdDegreePolynomial : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private int pointsPerUnit = 50;
    [SerializeField] private float A = 1.0f;
    [SerializeField] private float B = 0.0f;
    [SerializeField] private float C = 0.0f;
    [SerializeField] private float D = -1.0f;
    //private int length = domainEnd-domainStart;
    private float increment = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        increment = 1f / pointsPerUnit;
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
        lineRenderer.positionCount = (int)(domainEnd-domainStart) * pointsPerUnit;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = (A*x*x*x+B*x*x+C*x+D);
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

    