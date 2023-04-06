using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordPlane : MonoBehaviour
{
    [SerializeField] private Ball ballScript;
    [SerializeField] private int size = 1;
    [SerializeField] private float width = 0.10f;
    [SerializeField] private Color color;
    [SerializeField] private Material material;
    private int xMax;
    private int yMax;
    // Start is called before the first frame update
    void Start()
    {
        xMax = (int)Mathf.Abs(ballScript.DeathValX);
        yMax = (int)Mathf.Abs(ballScript.DeathValY);
        Debug.Log(color.a);
        for(int i = -xMax; i <= xMax; i += size){
            DrawPlaneLine(new Vector2(i, -yMax), new Vector2(i, yMax), width, color, material);
        }
        for(int j = -yMax; j <= yMax; j += size){
            DrawPlaneLine(new Vector2(-xMax, j), new Vector2(xMax, j), width, color, material);
        }
    }

    private void DrawPlaneLine(Vector2 startPt, Vector2 endPt, float width, Color color, Material material){
        GameObject line = new GameObject();
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        if(startPt.x == 0 || startPt.y == 0){
            color.a += 0.25f;
            width *= 3f;
        }
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.SetPosition(0, new Vector3(startPt.x, startPt.y));
        lineRenderer.SetPosition(1, new Vector3(endPt.x, endPt.y));
        lineRenderer.sortingLayerName = "CoordinateGrid";
        line.transform.SetParent(transform);
    }
    

}
