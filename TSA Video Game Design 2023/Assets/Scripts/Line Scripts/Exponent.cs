using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class Exponent : LineMaster, ILine
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
    }
    public void UpdateParams(){
        a = float.Parse(aInput.text, CultureInfo.InvariantCulture.NumberFormat);
        c = float.Parse(cInput.text, CultureInfo.InvariantCulture.NumberFormat);
        d = float.Parse(dInput.text, CultureInfo.InvariantCulture.NumberFormat);
    }

    // Start is called before the first frame update

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
        return Mathf.Pow(a,(x-c))+d;
    }


}

