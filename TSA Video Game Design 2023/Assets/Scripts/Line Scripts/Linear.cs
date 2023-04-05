using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class Linear : LineMaster, ILine
{
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private TMP_InputField aInput;
    [SerializeField] private TMP_InputField dInput;
    private float a;
    private float d;
    // Start is called before the first frame update
    void Start(){
        UpdateParams();
        MakeLine();
    }
    public void UpdateParams(){
        a = float.Parse(aInput.text, CultureInfo.InvariantCulture.NumberFormat);
        d = float.Parse(dInput.text, CultureInfo.InvariantCulture.NumberFormat);
        Debug.Log(a);
        Debug.Log(d);
    }
    public override float DomainStart{
        set{domainStart = value;}
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
        return a*x+d;
    }

    
}

