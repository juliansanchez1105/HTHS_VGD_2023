using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquationField : MonoBehaviour, IDropHandler
{
    private RectTransform rTransform;
    private RectTransform dropTransform;
    void Start(){
        rTransform = GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag.gameObject.tag == "Draggable")
        {
            dropTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            dropTransform.SetParent(rTransform);
            Debug.Log(eventData.pointerDrag.GetComponent<DragDrop>().OgPosition);
            dropTransform.anchoredPosition = eventData.pointerDrag.GetComponent<DragDrop>().OgPosition;

            eventData.pointerDrag.GetComponent<DragDrop>().Snapped();
            //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
            //Debug.Log(GetComponent<RectTransform>().position);

            //Remove Line
            eventData.pointerDrag.GetComponent<Line>().LineActive(false);

        }
    }

}
