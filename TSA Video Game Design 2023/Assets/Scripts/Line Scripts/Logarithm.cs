using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class Logarithm : LineMaster, ILine
{
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private TMP_InputField aInput;
    [SerializeField] private TMP_InputField cInput; //horizontal shift
    [SerializeField] private TMP_InputField dInput; //vertical shift
    private float a;
    private float c; //horizontal shift
    private float d; //vertical shift
    // Start is called before the first frame update
    void Start(){
        UpdateParams();
        MakeLine();
        DomainStart = domainStart;
    }
    public void UpdateParams(){
        a = Mathf.Abs(float.Parse(aInput.text, CultureInfo.InvariantCulture.NumberFormat));
        aInput.text = a.ToString();
        c = float.Parse(cInput.text, CultureInfo.InvariantCulture.NumberFormat);
        d = float.Parse(dInput.text, CultureInfo.InvariantCulture.NumberFormat);
    }

    // Start is called before the first frame update

    public override List<Vector2> Draw(Vector3 startPoint)
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
        DomainStart = domainStart;
        float x = DomainStart;
        float y;
        lineRenderer.positionCount = (int)((DomainEnd-DomainStart) * (1/increment)) + 1;
        if(a > 0 && DomainStart == c){
            lineRenderer.SetPosition(0, new Vector3(c, ball.DeathValY * -1, 0));
            points.Add(new Vector2(c, ball.DeathValY * -1));
        }
        else if(a < 0 && DomainStart == c){
            lineRenderer.SetPosition(0, new Vector3(c, ball.DeathValY, 0));
            points.Add(new Vector2(c, ball.DeathValY));
        }
        else{
            lineRenderer.positionCount--;
        }
        for (int i = 1; i < lineRenderer.positionCount; i++)
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

    public override float DomainStart{
        set{
            if(value >= c){
                domainStart = value;
            }
            else{
                domainStart = c;
            }
            //Debug.Log("DomainStart: " + domainStart);
        }
        get{return domainStart;}
    }
    public override float DomainEnd{
        set{domainEnd = value;}
        get{return domainEnd;}
    }

    public override EdgeCollider2D Collider()
    {
        return GetComponent<EdgeCollider2D>();
    }

    public override float Equation(float x){
        return Mathf.Log((x-c), a)+d;
    }



}


