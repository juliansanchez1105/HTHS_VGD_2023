using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Linear : LineMaster
{
    private LineRenderer lineRenderer;
    private float increment;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private float m = 1.0f;
    [SerializeField] private float b = 0.0f;
    //private int length = domainEnd-domainStart;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        increment = 0.01f;
    }

    

    
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
        return m*x+b;
    }

    
}

