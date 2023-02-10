using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DrawStraightLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private TMPro.TMP_InputField slope; //slope
    [SerializeField] private TMPro.TMP_InputField yIntercept; //y-intercept
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
        //need to add buttons for domain, show or not show, delete
        float m = 0;
        float b = 0;

        if(slope.text!= null)
            m = float.Parse(slope.text, CultureInfo.InvariantCulture.NumberFormat);
        if(yIntercept.text!=null)
            b = float.Parse(yIntercept.text, CultureInfo.InvariantCulture.NumberFormat);
        

        List<Vector2> points = new List<Vector2>();
        float x = domainStart;
        float y;
        lineRenderer.positionCount = (int)((domainEnd-domainStart) * (1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = (m*x+b);
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

