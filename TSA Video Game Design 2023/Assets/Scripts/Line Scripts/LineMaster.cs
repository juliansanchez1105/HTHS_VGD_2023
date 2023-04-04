using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class LineMaster : MonoBehaviour
{
    public abstract float DomainStart{set; get;}
    public abstract float DomainEnd{set; get;}
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float increment = 0.05f;
    public abstract EdgeCollider2D Collider();
    public abstract float Equation(float x);
    [SerializeField] private Ball ball;
    [SerializeField] private Negation negation;
    private bool startsNegated;
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

        if(-1 * ball.DeathValX > DomainStart){
            DomainStart = -1 * ball.DeathValX;
        }
        if(!ValidX(DomainStart) && !ValidY(Equation(DomainStart))){
            startsNegated = true;
        }
        else{
            startsNegated = false;
        }
        if(ball.DeathValX < DomainEnd){
            DomainEnd = ball.DeathValX;
        }
        float x = DomainStart;
        float y;
        lineRenderer.positionCount = (int)((DomainEnd-DomainStart) * (1/increment));
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x += increment;
            y = Equation(x);
            if(ValidY(y) || ValidX(x)){
                lineRenderer.SetPosition(i, new Vector3(x, y, 0));
                points.Add(new Vector2(x, y));
            }
            else if(startsNegated){
                lineRenderer.positionCount--;
                i--;
            }
            else{
                lineRenderer.positionCount = i - 1;
                break;
            }
        }
        
        return points;
    }

    void GenerateCollider(List<Vector2> points)
    {
        Collider().SetPoints(points);

    }

    private bool ValidY(float y){
        if(y > -1 * ball.DeathValY && y < ball.DeathValY){
            if(negation){
                if(y >= negation.TopLeft.y || y <= negation.BottomRight.y){
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return true;
            }
        }
        else{
            return false;
        }
    }

    private bool ValidX(float x){
        if(negation){
            if(x <= negation.TopLeft.x || x >= negation.BottomRight.x){
                return true;
            }
            else{
                return false;
            }
        }
        else{
            return true;
        }
    }

}
