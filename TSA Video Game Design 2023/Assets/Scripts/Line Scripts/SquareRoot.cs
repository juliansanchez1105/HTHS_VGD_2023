using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class SquareRoot : LineMaster, ILine
{
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private TMP_InputField aInput;
    [SerializeField] private TMP_InputField cInput;
    [SerializeField] private TMP_InputField dInput;
    private float a;
    private float c;
    private float d;
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
    public override float DomainStart{
        set{
            if(value >= -1 * c){
                domainStart = value;
            }
            else{
                domainStart = -1 * c;
            }
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
        return (a * Mathf.Sqrt(x - c) + d);
    }
}

    
