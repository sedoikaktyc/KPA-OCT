using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour, IDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {

        transform.parent.GetComponent<RectTransform>().anchoredPosition += eventData.delta / transform.parent.GetComponentInParent<Canvas>().scaleFactor;
    }




}
