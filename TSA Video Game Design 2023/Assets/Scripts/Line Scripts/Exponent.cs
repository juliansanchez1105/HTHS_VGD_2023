using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exponent : LineMaster
{

    private LineRenderer lineRenderer;
    private float increment;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private float a = 1.0f;
    [SerializeField] private float b = 20.0f; //horizontal shift
    [SerializeField] private float c = 20.0f; //vertical shift
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        increment = 0.01f;
    }

    // Start is called before the first frame update

    public override float DomainStart()
    {
        return domainStart;
    }
    public override float DomainEnd()
    {
        return domainEnd;
    }
    public override LineRenderer LineRender()
    {
        return lineRenderer;
    }
    public override float IncrementGet(){
        return increment;
    }
    public override EdgeCollider2D Collider()
    {
        return GetComponent<EdgeCollider2D>();
    }

    public override float Equation(float x){
        return Mathf.Pow(a,(x-b))+c;
    }


}

