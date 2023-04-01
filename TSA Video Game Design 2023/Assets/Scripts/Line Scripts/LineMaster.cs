using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class LineMaster : MonoBehaviour
{
    public abstract float DomainStart();
    public abstract float DomainEnd();
    public abstract LineRenderer LineRender();
    public abstract float IncrementGet();
    public abstract EdgeCollider2D Collider();
    public abstract float Equation(float x);
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        GenerateCollider(Draw(new Vector3(DomainStart(), 0.0f, 0.0f)));
    }

    List<Vector2> Draw(Vector3 startPoint)
    {
        //need to add buttons for domain, show or not show, delete
        

        List<Vector2> points = new List<Vector2>();
        float x = DomainStart();
        float y;
        LineRender().positionCount = (int)((DomainEnd()-DomainStart()) * (1/IncrementGet()));
        for (int i = 0; i < LineRender().positionCount; i++)
        {
            x += IncrementGet();
            y = Equation(x);
            LineRender().SetPosition(i, new Vector3(x, y, 0));
            points.Add(new Vector2(x, y));
        }
        
        return points;
    }

    void GenerateCollider(List<Vector2> points)
    {
        Collider().SetPoints(points);

    }

}
