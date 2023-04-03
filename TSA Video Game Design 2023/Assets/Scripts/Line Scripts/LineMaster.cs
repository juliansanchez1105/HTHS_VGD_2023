using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class LineMaster : MonoBehaviour
{
    public abstract float DomainStart{set; get;}
    public abstract float DomainEnd{set; get;}
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float increment = 0.1f;
    public abstract EdgeCollider2D Collider();
    public abstract float Equation(float x);
    [SerializeField] private Ball ball;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        MakeLine();
    }

    public void MakeLine(){
        //Debug.Log("Make Line");
        GenerateCollider(Draw(new Vector3(DomainStart, 0.0f, 0.0f)));
    }

    List<Vector2> Draw(Vector3 startPoint)
    {
        //need to add buttons for domain, show or not show, delete
        List<Vector2> points = new List<Vector2>();
        float x = DomainStart;
        float y;
        lineRenderer.positionCount = (int)((DomainEnd-DomainStart) * (1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = Equation(x);
            if(y >= -1 * ball.DeathValY && y <= ball.DeathValY){
                lineRenderer.SetPosition(i, new Vector3(x, y, 0));
                points.Add(new Vector2(x, y));
            }
            else{
                lineRenderer.positionCount--;
                i--;
            }
        }
        
        return points;
    }

    void GenerateCollider(List<Vector2> points)
    {
        Collider().SetPoints(points);

    }

}
