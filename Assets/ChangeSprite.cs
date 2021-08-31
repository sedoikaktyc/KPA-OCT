using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{


    public Sprite Image;
    // Start is called before the first frame update


    private void OnEnable()
    {
        
        foreach (Transform Item in transform) {

            Item.GetChild(0).GetChild(0).gameObject.GetComponent<ObjectsOnImage>().Image = Image;
        }

        

    }


    void Start()

    {
        foreach (Transform Item in transform)
        {

            Item.GetChild(0).GetChild(0).gameObject.GetComponent<ObjectsOnImage>().ChangeImages();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
