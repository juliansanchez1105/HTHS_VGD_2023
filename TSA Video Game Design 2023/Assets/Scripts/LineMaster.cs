using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class LineMaster : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float increment;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private List<TMPro.TMP_InputField> inputs; //inputs from function
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
        //need to add buttons for domain, show or not show, delete
        

        List<Vector2> points = new List<Vector2>();
        float x = domainStart;
        float y;
        lineRenderer.positionCount = (int)((domainEnd-domainStart) * (1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = Exponent(x);
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

    private float Exponent(float x){
        float a = float.Parse(inputs[0].text, CultureInfo.InvariantCulture.NumberFormat);
        float b = float.Parse(inputs[1].text, CultureInfo.InvariantCulture.NumberFormat);
        float k = float.Parse(inputs[2].text, CultureInfo.InvariantCulture.NumberFormat);
        float d = float.Parse(inputs[3].text, CultureInfo.InvariantCulture.NumberFormat);
        float c = float.Parse(inputs[4].text, CultureInfo.InvariantCulture.NumberFormat);

        return a * Mathf.Pow(b, k * (x-d)) + c;
    }
}
