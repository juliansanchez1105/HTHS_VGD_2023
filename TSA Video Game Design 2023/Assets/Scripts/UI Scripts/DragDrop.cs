using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private Vector2 position;
    private CanvasGroup canvasGroup;
    private Vector2 ogPosition;
    private GameObject parentObject;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start(){
        ogPosition = rectTransform.anchoredPosition;
        Debug.Log(ogPosition);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        position = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        parentObject = rectTransform.parent.gameObject;
        rectTransform.SetParent(canvas.GetComponent<RectTransform>());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(rectTransform.parent.gameObject.name == "Canvas"){
            rectTransform.SetParent(parentObject.GetComponent<RectTransform>());
        }
        GetComponent<RectTransform>().anchoredPosition = position;

    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void Snapped()
    {
        position = rectTransform.anchoredPosition;
    }

    public Vector2 OgPosition{
        get{return ogPosition;}
    }

}

