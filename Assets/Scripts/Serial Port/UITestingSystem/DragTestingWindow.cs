using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTestingWindow : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private RectTransform testWindow;

    [SerializeField]
    private Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        testWindow.anchoredPosition += eventData.delta/ canvas.scaleFactor;
    }

}
