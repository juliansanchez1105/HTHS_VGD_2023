using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    //[SerializeField] private int resolution = 200;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateCollider(Draw(new Vector3(0, 0, 0), 1000, 4, 2, 0));
    }

    

    // Update is called once per frame
    void Update()
    {
        //Draw(new Vector3(-10, 0, 0), 2000, 4, 2, 5);
    }


    List<Vector2> Draw(Vector3 startPoint, int n, float wavelength, int amplitude, int speed)
    {
        List<Vector2> points = new List<Vector2>();
        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        lineRenderer.positionCount = n;
        for (int i = 0; i < n; i++)
        {
            x += 0.0001f * i;
            y = amplitude * Mathf.Sin(k * x + (k * speed * Time.time));
            lineRenderer.SetPosition(i, new Vector3(x, y, 0) + startPoint);
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
