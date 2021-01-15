using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    /*private DragDrop dragDrop;
    private bool occupied = false;*/
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null /*&& !occupied*/)
        {
            /*eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;*/ //old code, dont need, no.

            eventData.pointerDrag.GetComponent<RectTransform>().localPosition =
                GetComponent<RectTransform>().localPosition;
            /*occupied = true;
            dragDrop.active = true;
            Debug.Log("Occupied");*/
        }

        /*if(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition !=
                GetComponent<RectTransform>().anchoredPosition)
        {
            Debug.Log("Unoccupied");
            occupied = false;
        }*/
    }
}
