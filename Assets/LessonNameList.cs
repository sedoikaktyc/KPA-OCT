using System.Collections;
using System.Collections.Generic;
using UnityEngine;





    public class LessonNameList : MonoBehaviour
    {

        public static LessonNameList Instatiate;

        public string Lesson_Name;


    private void Awake()
    {
        if (Instatiate == null)
        {
            Instatiate = this;
        }

        DontDestroyOnLoad(Instatiate);



    }




    }



