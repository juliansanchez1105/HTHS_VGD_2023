using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : LineMaster
{
    private LineRenderer lineRenderer;
    [SerializeField] private float domainStart = -5.0f;
    [SerializeField] private float domainEnd = 5.0f;
    [SerializeField] private float a = 1.0f;
    [SerializeField] private float b = 1.0f;
    [SerializeField] private float c = 0.0f;
    [SerializeField] private float d = 0.0f;
    private float increment;
    
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
        return a * Mathf.Sin(b * (x + c)) + d;
    }

}
