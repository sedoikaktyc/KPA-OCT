using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class promtTextChanger : MonoBehaviour
{
    public Text ScrollVievText;
    public static promtTextChanger Instance;
    // Start is called before the first frame update

    public string[] promtsString;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeText(int btn) {
        //Debug.Log("changePromt - " + btn);
        ScrollVievText.text = promtsString[btn];
        gameObject.GetComponentInChildren<ScrollRect>().normalizedPosition = new Vector2(transform.GetComponentInChildren<ScrollRect>().normalizedPosition.x, 1);
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.GetComponentInChildren<ScrollRect>().normalizedPosition = new Vector2(transform.GetComponentInChildren<ScrollRect>().normalizedPosition.x, 1);
        }
    }



}
