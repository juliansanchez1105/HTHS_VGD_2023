using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquationSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rTransform;
    private RectTransform dropTransform;
    [SerializeField] private GameObject parent;
    private float ogWidth;
    private float ogHeight;
    private float ogParentWidth;
    private float ogParentHeight;
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
        if (eventData.pointerDrag != null)
        {
            dropTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            dropTransform.SetParent(rTransform);
            dropTransform.anchoredPosition = new Vector2(0, 0);

            eventData.pointerDrag.GetComponent<DragDrop>().Snapped();
            //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            //Debug.Log(GetComponent<RectTransform>().position);

            rTransform.sizeDelta = new Vector2(dropTransform.sizeDelta.x, rTransform.sizeDelta.y);
        }
    }

    void OnTransformChildrenChanged(){
        if(transform.childCount == 0){
            rTransform.sizeDelta = new Vector2(ogWidth, ogHeight);
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(ogParentWidth, ogParentHeight);            
        }
        else{
            rTransform.sizeDelta = new Vector2(dropTransform.sizeDelta.x, rTransform.sizeDelta.y);
            //Debug.Log(parent.GetComponent<RectTransform>().sizeDelta);
            parent.GetComponent<RectTransform>().sizeDelta = new Vector2(ogParentWidth - ogWidth + rTransform.sizeDelta.x, ogParentHeight);
            //Debug.Log(parent.GetComponent<RectTransform>().sizeDelta);
        }
    }
}
