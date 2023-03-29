using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private int pointsPerUnit = 50;
    [SerializeField] private int length = 20;
    private float increment;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        increment = 1f / pointsPerUnit;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        GenerateCollider(Draw(new Vector3(-length / 2.0f, 0.0f, 0.0f), length, 4, 1f));
    }


    List<Vector2> Draw(Vector3 startPoint, int length, float wavelength, float amplitude)
    {
        List<Vector2> points = new List<Vector2>();
        float x = 0f;
        float y;
        lineRenderer.positionCount = length * pointsPerUnit;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = amplitude * Mathf.Sin(2 * (Mathf.PI / wavelength) * x);;
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

