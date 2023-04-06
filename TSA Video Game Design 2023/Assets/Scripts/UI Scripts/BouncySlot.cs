using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BouncySlot : MonoBehaviour, IDropHandler
{
    private RectTransform rTransform;
    private RectTransform dropTransform;
    [SerializeField] private GameObject parent;
    [SerializeField] private PlayerControl manager;
    [SerializeField] private Ball ball;
    [SerializeField] private PhysicsMaterial2D bouncy;
    [SerializeField] private PhysicsMaterial2D equation;
    private float ogWidth;
    private float ogHeight;
    private float ogParentWidth;
    private float ogParentHeight;
    private GameObject childEq;
    // private Color green = new Color(66, 245, 105, 1);
    // private Color white = new Color(1, 1, 1, 1);
    void Start(){
        rTransform = GetComponent<RectTransform>();
        ogWidth = rTransform.sizeDelta.x;
        ogHeight = rTransform.sizeDelta.y;
        ogParentWidth = parent.GetComponent<RectTransform>().sizeDelta.x;
        ogParentHeight = parent.GetComponent<RectTransform>().sizeDelta.y;

    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag.gameObject.tag == "Draggable")
        {
            childEq = eventData.pointerDrag.gameObject.GetComponent<Line>().LineType;
            dropTransform = eventData.pointerDrag.gameObject.GetComponent<RectTransform>();
            dropTransform.SetParent(rTransform);
            dropTransform.anchoredPosition = new Vector2(0, 0);

            eventData.pointerDrag.gameObject.GetComponent<DragDrop>().Snapped();
            //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            //Debug.Log(GetComponent<RectTransform>().position);

            rTransform.sizeDelta = new Vector2(dropTransform.sizeDelta.x, rTransform.sizeDelta.y);

            //Draw Line
            eventData.pointerDrag.gameObject.GetComponent<Line>().LineActive(true);
        }
    }

    void OnTransformChildrenChanged(){
        if(transform.childCount == 0){
            childEq.GetComponent<EdgeCollider2D>().sharedMaterial = equation;
            // childEq.GetComponent<LineRenderer>().startColor = white;
            // childEq.GetComponent<LineRenderer>().endColor = white;
            // childEq.GetComponent<LineRenderer>().material.color = white;
            rTransform.sizeDelta = new Vector2(ogWidth, ogHeight);
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(ogParentWidth, ogParentHeight);            
        }
        else{
            childEq.GetComponent<EdgeCollider2D>().sharedMaterial = bouncy;
            // childEq.GetComponent<LineRenderer>().startColor = green;
            // childEq.GetComponent<LineRenderer>().endColor = green;
            // childEq.GetComponent<LineRenderer>().material.color = green;
            rTransform.sizeDelta = new Vector2(dropTransform.sizeDelta.x, rTransform.sizeDelta.y);
            //Debug.Log(parent.GetComponent<RectTransform>().sizeDelta);
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(ogParentWidth - ogWidth + rTransform.sizeDelta.x, ogParentHeight);
            //Debug.Log(parent.GetComponent<RectTransform>().sizeDelta);
            ChangeLine();
        }

        manager.timeStop();
        ball.Death();
    }

    public void ChangeLine(){
        try {GetComponentInChildren<Line>().LineType.GetComponent<ILine>().MakeLine();} catch{Debug.Log("Failed to change line.");};
    }
}
