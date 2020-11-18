using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    /*private Vector2 origPosition;
    public bool active = false;
    private Image image;*/

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        /*origPosition = rectTransform.anchoredPosition;*/ //old code, dont need, no.
        /*(Vector3)origPosition = rectTransform.localPosition;*/
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        /*rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;*/ //old code, dont need, no.
        rectTransform.localPosition += (Vector3)eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");

        /*if(active == false)
        {
            rectTransform.anchoredPosition = origPosition;
            image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
        }

        else
        {
            image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }*/
        
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;


    }

    public void OnPointerDown(PointerEventData eventDate)
    {
        Debug.Log("PointerDown");
    }
}
