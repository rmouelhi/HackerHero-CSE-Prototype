using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollContent : MonoBehaviour
{
    public RectTransform parent;
    public RectTransform child;

    private float scrollValue;

    private Vector2 parentAnchorMin;
    private Vector2 parentAnchorMax;

    private Vector2 childAnchorMin;
    private Vector2 childAnchorMax;
    private Vector2 childOffsetMin;
    private Vector2 childOffsetMax;

    private Vector2 barMin;
    private Vector2 barMax;

    // Start is called before the first frame update
    void Start()
    {
        scrollValue = gameObject.GetComponent<Scrollbar>().value;

        parentAnchorMin = parent.GetComponent<RectTransform>().anchorMin;
        parentAnchorMax = parent.GetComponent<RectTransform>().anchorMax;

        childAnchorMin = child.GetComponent<RectTransform>().anchorMin;
        childAnchorMax = child.GetComponent<RectTransform>().anchorMax;
        childOffsetMin = child.GetComponent<RectTransform>().offsetMin;
        childOffsetMax = child.GetComponent<RectTransform>().offsetMax;

        // x = Top, y = Bottom // Needs Naming Overhaul
        barMin = new Vector2(childAnchorMin.y, 0);
        barMax = new Vector2(childAnchorMax.y, Mathf.Abs(childAnchorMax.y - childAnchorMin.y));
    }

    public void MoveContent()
    {
        scrollValue = gameObject.GetComponent<Scrollbar>().value;
        
        // Needs Naming Overhaul
        childAnchorMin.y = LocalToGlobal(scrollValue, barMin.x, barMin.y);
        childAnchorMax.y = LocalToGlobal(scrollValue, barMax.x, barMax.y);

        child.GetComponent<RectTransform>().anchorMin = childAnchorMin;
        child.GetComponent<RectTransform>().anchorMax = childAnchorMax;
        child.GetComponent<RectTransform>().offsetMin = childOffsetMin;
        child.GetComponent<RectTransform>().offsetMax = childOffsetMax;
    }

    private float LocalToGlobal(float _value, float _min, float _max)
    {
        return (1 - _value) * _min + _value * _max;
    }
}
