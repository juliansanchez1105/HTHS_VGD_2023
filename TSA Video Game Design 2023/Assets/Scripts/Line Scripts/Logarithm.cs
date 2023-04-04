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

    public override float DomainStart{
        set{
            if(value >= -1 * c){
                domainStart = value;
            }
            else{
                domainStart = -1 * c;
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


