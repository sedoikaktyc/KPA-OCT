using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class controlButtonMouseController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text ButtonText;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

        Color newColor = new Color(1.0f, 0.0f, 0.0f, 0.8f);
        ButtonText.DOColor(newColor, 0.1f);
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Color newColor = new Color(0.33f, 0.0f, 0.0f, 1.0f);
        ButtonText.DOColor(newColor, 0.1f);
        Debug.Log("OnPointerOut");
    }

}
