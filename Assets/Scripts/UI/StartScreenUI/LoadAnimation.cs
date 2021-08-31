using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAnimation : MonoBehaviour
{


    private readonly List<GameObject> _cubes = new List<GameObject>();
    private readonly List<Color> _cubesColor = new List<Color>();

    private int cubeFullColor = 0;
    private int cubeHalfColor = -1;
    private int cubeFourthColor = -2;

    private bool endAnimatation = false;
    // Start is called before the first frame update
    private void Awake()
    {
        GetAllCubes();
        StartCoroutine(AnimateLoad());
    }



    private void GetAllCubes()
    {

        int childrenCount = transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            _cubes.Add(transform.GetChild(i).gameObject);

        }
    }
   

    IEnumerator AnimateLoad()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (cubeHalfColor >= 0)
            {
                _cubes[cubeHalfColor].GetComponent<Image>().color = new Color(0.1137255f, 0.1098039f, 0.1098039f, 0.75f);
            }

            if (cubeFourthColor >= 0)
            {
                _cubes[cubeFourthColor].GetComponent<Image>().color = new Color(0.1137255f, 0.1098039f, 0.1098039f, 0.5f);
            }

            _cubes[cubeFullColor].GetComponent<Image>().color = new Color(0.1137255f, 0.1098039f, 0.1098039f, 1f);

            for (int i = 0; i < _cubes.Count; i++)
            {
                if (i != cubeFullColor && i != cubeHalfColor && i != cubeFourthColor)
                {
                    _cubes[i].GetComponent<Image>().color = new Color(0.1137255f, 0.1098039f, 0.1098039f, 0f);
                }
            }


            cubeFullColor = ReSetIndex(cubeFullColor);
            cubeFourthColor = ReSetIndex(cubeFourthColor);
            cubeHalfColor = ReSetIndex(cubeHalfColor);
        }
    }

    private int ReSetIndex(int index)
    {
        index++;

        if (index >= _cubes.Count)
        {
            return 0;
        }

        return index;
    }
}
