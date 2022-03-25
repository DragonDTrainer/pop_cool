using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class Draggable : EventTrigger
{

    public bool dragging;
    public Vector3 startPosition;
    RectTransform rt;
    Image img;
    private void Start()
    {
        rt = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }
    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            img.raycastTarget = false;
        }
        else
        {
            rt.anchoredPosition = startPosition;
            img.raycastTarget = true;

        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
