using ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialScene : MonoBehaviour
{
    public GameObject StartLessonButton;

    private void Start() {
        StartLessonButton.GetComponent<Button>().onClick.AddListener(GoToLessonScene);
    }

    private void GoToLessonScene()
    {
        SceneManager.LoadScene(2);
    }

    public void ShowStartLessonButton(bool status) {
        StartLessonButton.SetActive(status);
    }
}
