using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ChangeSlederValue : MonoBehaviour
{
    public Slider _slider;

    // Start is called before the first frame update
    public void changeValue(float a, float b)
    {
        //Debug.Log("Slider value --- " + a + " - " + b);
        float c = a / b;
        //Debug.Log("c --- " + c);
        _slider.DOValue(c, 0.4f).SetLoops(1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
