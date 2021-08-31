using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoginType : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject ListPanel;
    bool _login = true;

    [SerializeField]
    private Sprite _list, _signIn;
    [SerializeField]
    private Button _signInBtn, _runVOsignBtn;

    // Start is called before the first frame update
    void Awake()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(ListPanel.transform.DOScaleX(0.0f, 0.0f));
        mySequence.Play();
    }
    private void Start()
    {
        _signInBtn.Select();
    }

    void Update()
    {

            if (Input.GetKeyDown("enter"))
        {

            Debug.Log("enter");

            if (_login)
            {
                _signInBtn.onClick.Invoke();

            }
            else
            {

                _runVOsignBtn.onClick.Invoke();
            }
        }
    }

    public void ChangeLoginType()
    {

        if (_login)
        {

            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(LoginPanel.transform.DOScaleX(0.0f, 0.2f));
            mySequence.Append(ListPanel.transform.DOScaleX(1.0f, 0.2f));
            mySequence.Play();
            _login = !_login;
            GetComponent<Image>().sprite = _signIn;

        }
        else
        {
            Sequence mySequence = DOTween.Sequence();

            mySequence.Append(ListPanel.transform.DOScaleX(0.0f, 0.2f));
            mySequence.Append(LoginPanel.transform.DOScaleX(1.0f, 0.2f));
            mySequence.Play();
            _login = !_login;
            GetComponent<Image>().sprite = _list;

        }





    }



}
