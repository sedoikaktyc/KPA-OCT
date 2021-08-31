using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataFromXML;
using DataFromArduino;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Reflection.Emit;

public class AllSceneMetods : MonoBehaviour
{

    public string PziName;
    public GameObject PziGameObject;
    public GameObject PziPrefab;
    public GameObject PanelManager;
    private Component scrollScript;
    private Component pziScript;
    public GameObject EtapLoader;
   


    public int Step;
    public int StepsCount;

    public GameObject NextBotton;

    public static AllSceneMetods SceneMetods;


    public GameObject StepText;
    private Text StepTextAsText;
    public GameObject StepNumberText;
    private Text StepNumberTextAsText;
    public infoLoader INFO;


    private string ellementAnswer;
    private string blockAnswer;

    public int Etap;


    public bool StillPzi = true;


    public string ControlString;
    public string ActionString;
    public string ThirdEtapString;

    public GameObject AnimationUp;
    public GameObject AnimationDown;

    public GameObject PziNameText;

    private int answerFromArduino;



    public bool controlStepFlag;
    public List<controlElements> controlStepAnswer = new List<controlElements>();
    public List<AllAnswerlements> AllAnswersAtMonitor = new List<AllAnswerlements>();

    [System.Serializable]
    public class controlElements
    {
        public string ElementName;
        public string LabelText;
        public GameObject BlockAtControlAnswer;


    }

    [System.Serializable]
    public class AllAnswerlements
    {
        public GameObject Element;
    }

    public void AddElement(GameObject Obj)
    {

        AllAnswersAtMonitor.Add(new AllAnswerlements());
        AllAnswersAtMonitor[AllAnswersAtMonitor.Count - 1].Element = Obj;
        //Debug.Log(AllAnswersAtMonitor.Count);
        //Debug.Log(AllAnswersAtMonitor[AllAnswersAtMonitor.Count - 1].Element.name);
        //Debug.Log(AllAnswersAtMonitor.Count);

    }

    public void DelElement(GameObject Obj)
    {

        //Debug.Log(AllAnswersAtMonitor.Count);
        var item = AllAnswersAtMonitor.Find(Obj => AllAnswersAtMonitor.Remove(Obj));
        //Debug.Log(AllAnswersAtMonitor.Count);
        //Debug.Log(AllAnswersAtMonitor[AllAnswersAtMonitor.Count - 1].Element.name);


    }

    public void AddControlElement(GameObject Obj, string text, GameObject Block)
    {
        //Debug.Log("AddControlElement");
        controlStepAnswer.Add(new controlElements());
        controlStepAnswer[controlStepAnswer.Count - 1].ElementName = Obj.name;
        controlStepAnswer[controlStepAnswer.Count - 1].LabelText = text;
        controlStepAnswer[controlStepAnswer.Count - 1].BlockAtControlAnswer = Block;
        // Debug.Log(controlStepAnswer.Count);
        ControlPanel.Instance.OnReceivedModels(text, Obj, Block);

    }

    public void DelControlElement(GameObject Obj)
    {
        Debug.Log("del === " + Obj.name);
        for (int i = 0; i < controlStepAnswer.Count; i++)
        {
            if (controlStepAnswer[i].ElementName == Obj.name)
            {

                controlStepAnswer.RemoveAt(i);
                break;
            }

        }
        //var item = controlStepAnswer.Find(Obj => controlStepAnswer.Remove(Obj));
        //controlStepAnswer.Remove(controlStepAnswer.Find(Obj.name));
        Debug.Log(controlStepAnswer.Count);

    }

    public void FindAllControllObjAndUNcheked()
    {

        //Debug.Log("FindAllControllObjAndUNcheked");

        Color newColorStart = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        foreach (var Item in controlStepAnswer)
        {

            foreach (Transform child in Item.BlockAtControlAnswer.transform.GetChild(0).GetChild(0).transform)
            {
                //Debug.Log(Item.BlockAtControlAnswer.transform.GetChild(0).GetChild(0).transform);

                if (child.gameObject.name == Item.ElementName)
                {

                    child.gameObject.GetComponent<Image>().DOColor(newColorStart, 0.1f);
                    child.GetComponent<ImageFlag>().IsClicked = false;
                    break;
                }


            }

        }




    }



    public void FindObjAndUNcheked(GameObject Block, GameObject Obj)
    {

        Block.transform.GetChild(0).GetChild(0);

        foreach (Transform child in Block.transform.GetChild(0).GetChild(0).transform)
        {
            if (child.gameObject == Obj)
            {
                Color newColorStart = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                child.GetComponent<Image>().DOColor(newColorStart, 0.1f);
                child.GetComponent<ImageFlag>().IsClicked = false;
                break;
            }
        }
    }


    public static class GameObjectExtension
    {
        public static UnityEngine.Object Find(string name, System.Type type)
        {
            UnityEngine.Object[] objects = Resources.FindObjectsOfTypeAll(type);
            foreach (var obj in objects)
            {
                if (obj.name == name)
                {
                    return obj;
                }
            }
            return null;
        }



        public static GameObject Find(string name)
        {
            return Find(name, typeof(GameObject)) as GameObject;
        }


    }




    private void Awake()
    {
        SceneMetods = this;
        DevicesManager.MessageFromDeviceReady += CheckString;
        PziName = PracticalLessonNumber.LessonNumber;
        Debug.Log("PziName --- " + PziName);
        PziNameText.GetComponent<Text>().text = PziName;
        PziPrefab = PziGameObject.transform.Find(PziName).gameObject;
        PziPrefab.GetComponent<xmlManager>().enabled = true;
        PziPrefab.SetActive(true);
        PanelManager.GetComponent<scrollItems>().xmlMan = PziPrefab.GetComponent<xmlManager>();
        scrollScript = PanelManager.GetComponent<scrollItems>();
        StepsCount = PziPrefab.GetComponent<xmlManager>().PZI.Steps.Count;
        controlStepFlag = false;


    }

    public void ChangeEtap(int etap)
    {

        Etap = etap;
        gameObject.GetComponent<PziLogic>().StartStepFunction(PziName, Step);
        chengeStep(0);
        //Debug.Log(StepsCount);

    }

    public void LoadScene(int scene)
    {
        switch (scene)
        {
            case 1:
                UnsubscribeFromChecking();
                StartSceneController.Instance.LoadStartScene();
                break;

        }

    }

    // для дисконетка потребоволось выделить отдельный метод для отписки
    // дальнейшие подписки на события связанные с портом и
    // начальными условиями из XML init
    public void UnsubscribeFromChecking()
    {
        DevicesManager.MessageFromDeviceReady -= CheckString;
    }

    public void CheckString(string arduinoStr)
    {

        //Debug.Log("arduino message --- " + arduinoStr);
        string[] subs = arduinoStr.Split('#');
        gameObject.GetComponent<PziLogic>().ArduinoAction(subs);
        //Debug.Log("str --- " + checkObjStep(Step, (subs[0] + subs[1])));


        if (subs[2].Contains("."))
        {
            //Debug.Log(subs[2].Substring(0, subs[2].IndexOf(".")));
            answerFromArduino = Convert.ToInt32(subs[2].Substring(0, subs[2].IndexOf(".")));
        }
        else
        {
            answerFromArduino = Convert.ToInt32(subs[2]);

        }

        switch (Step)
        {





            case 0:
                if (checkObjStep(Step, (subs[0] + subs[1])))
                {
                    // obj from arduino RIGHT at step = 0


                    checkAnswer(answerFromArduino);






                }
                else
                {
                    // obj from arduino WRONG at step = 0
                    INFO.LoadInfoBox("Wrong Object at first step");


                }

                break;
            default:
                if (checkObjStep(Step, (subs[0] + subs[1])) || checkObjStep((Step - 1), (subs[0] + subs[1])))
                {
                    // obj from arduino RIGHT at step > 0
                    if (checkObjStep(Step, (subs[0] + subs[1]))) // ACTUAL step
                    {
                        checkAnswer(answerFromArduino);

                    }
                    else
                    { // last STEP

                        if (checkLastAnswerIsEnable(answerFromArduino))
                        {


                            checklastAnswer(answerFromArduino);

                        }
                        else
                        {


                            INFO.LoadInfoBox("Last Step Button or Monitor"); // Last Step Button or Monitor

                        }




                    }
                }
                else
                {
                    // obj from arduino WRONG at step > 0
                    /*
                    Debug.Log(subs[0] + subs[1]);
                    Debug.Log(checkObjStep(Step, (subs[0] + subs[1])));
                    */
                    INFO.LoadInfoBox("Wrong Object at now Step");
                }

                break;
        }




    }

    private void checklastAnswer(int answer) // sheck last answer if it is not a button or monitor
    {

        if (xmlManager.XML.FindFap(Step - 1) != 0)
        {
            if (xmlManager.XML.FindAnswer(Step - 1) >= (Convert.ToInt32(answer) - xmlManager.XML.FindFap(Step - 1)) && xmlManager.XML.FindAnswer(Step - 1) <= (Convert.ToInt32(answer) + xmlManager.XML.FindFap(Step - 1)))
            {
                // last step answer CORRECT
            }
            else
            {
                PreviousStep();
            }

        }
        else
        {
            if (xmlManager.XML.FindAnswer(Step - 1) != Convert.ToInt32(answer))
            {
                PreviousStep(); // no Button NO encoder INCORRECT answer last step
            }


        }



    }


    public void PreviousStep()
    {

        Step--;
        if (Step >= 0)
        {
            ChandeSliderValue(Step);
            chengeStep(Step);
            befStepArrow();
        }
        else
        {
            Debug.LogError("an attempt to change the step to negative");
            Step++;
        }



    }

    private bool checkLastAnswerIsEnable(int answer)
    {
        if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step - 1].TypeOfArduinoAnswer) == 1) // if last step is a button
        {


            if (answer == 0)
            {

                return true; // button UP
            }
            else
            {

                return false; // Button Push second Time
                Debug.Log("TypeOfArduinoAnswer --- " + Convert.ToInt32(xmlManager.XML.PZI.Steps[Step - 1].TypeOfArduinoAnswer));
            }


        }

        if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step - 1].TypeOfAnswer) != 2) // if last step is on MONITOR
        {
            Debug.Log("Type answer --- " + Convert.ToInt32(xmlManager.XML.PZI.Steps[Step - 1].TypeOfAnswer));
            return false;
        }



        return true;
    }

    private void checkAnswer(int answer)
    {


        if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfArduinoAnswer) == 2)
        { // not Button

            if (xmlManager.XML.FindFap(Step) != 0)
            {

                if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfAnswer) == 2) // Tipe - Arduino
                {

                    if (xmlManager.XML.FindAnswer(Step) >= (Convert.ToInt32(answer) - xmlManager.XML.FindFap(Step)) && xmlManager.XML.FindAnswer(Step) <= (Convert.ToInt32(answer) + xmlManager.XML.FindFap(Step)))
                    {
                        NextStep(); // no Button encoder CORRECT answer
                    }


                }
                else
                {


                    INFO.LoadInfoBox("Wrong Type of answer"); //правильный объект, но неправильное действие (нужно контролировать)

                }




            }
            else
            {

                if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfAnswer) == 2) // Tipe - Arduino
                {


                    if (xmlManager.XML.FindAnswer(Step) == Convert.ToInt32(answer))
                    {
                        NextStep(); // no Button NO encoder CORRECT answer
                    }


                }
                else
                {

                    INFO.LoadInfoBox("Wrong Type of answer"); //правильный объект, но неправильное действие (нужно контролировать)


                }





            }





        }
        else if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfArduinoAnswer) == 1)
        { // Button

            if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfAnswer) == 2) // Tipe - Arduino
            {

                if (Convert.ToInt32(answer) == 1)
                {

                    NextStep(); // Button CORRECT answer

                }

            }

            else
            {

                INFO.LoadInfoBox("Wrong Type of answer"); //правильный объект, но неправильное действие (нужно контролировать)


            }


        }

        else if (Convert.ToInt32(xmlManager.XML.PZI.Steps[Step].TypeOfArduinoAnswer) == 0)
        {

            INFO.LoadInfoBox("Wrong Type of answer"); //правильный объект, но неправильное действие (нужно контролировать)

        }





        }







    private bool checkObjStep(int step, string strFromArduino)
    {


        if (PziPrefab.GetComponent<xmlManager>().FindObjInStep(step).name == strFromArduino)
        {
            return true;

        }
        else
        {
            Debug.Log(PziPrefab.GetComponent<xmlManager>().FindObjInStep(step).name);
            Debug.Log(strFromArduino);

            return false;

        }



    }


    public void changeText(int step)
    {
        if (Etap != 3)
        {
            changeStepText(PziPrefab.GetComponent<xmlManager>().PZI.Steps[step].TextRu);
            changeNumberText(step);
        }


    }

    public void changeNumberText(int step)
    {

        StepNumberText.GetComponent<Text>().text = "Шаг #" + (step + 1);
        StepNumberTextAsText = StepNumberText.GetComponent<Text>();
        StepNumberTextAsText.DOColor(Color.gray, 0.1f).SetLoops(2, LoopType.Yoyo);
    }


    public void changeStepText(string stepString)
    {


        StepText.GetComponent<Text>().text = stepString;
        StepTextAsText = StepText.GetComponent<Text>();
        StepTextAsText.DOColor(Color.gray, 0.1f).SetLoops(2, LoopType.Yoyo);
        //StepTextAsText.DOFade(0,1);
    }



    // Start is called before the first frame update
    void Start()
    {
        PanelManager.GetComponent<scrollItems>().UpdateItems(0);
        pziScript = PziPrefab.GetComponent<xmlManager>();
        EtapLoader.GetComponent<infoLoader>().LoadEtapBox();

    }


    private void befStepArrow()
    {

        AnimationDown.GetComponent<Animator>().SetTrigger("down");

    }

    private void nextStepArrow()
    {

        AnimationUp.GetComponent<Animator>().SetTrigger("up");

    }

    public void NextStep()
    {





        gameObject.GetComponent<PziLogic>().StartStepFunction(PziName, Step);




        //INFO.LoadInfoBox("Step --- " + Step + "   StepsCount --- " + StepsCount);
        if (Step < StepsCount - 1)
        {

            
            Step++;
            chengeStep(Step);
            ChandeSliderValue(Step);

            //NextBotton

            nextStepArrow();


        }
        else
        {


            ChandeSliderValue(Step + 1);

            // CONGRATULATIONS
            Debug.Log("YRA");

        }




    }


    public void ChandeSliderValue(int value)
    {


        this.GetComponent<ChangeSlederValue>().changeValue(value, StepsCount);
    }

    private void ColoringObjAtStep(int stepNow)
    {

        GameObject[] objsAtStep = PziPrefab.GetComponent<xmlManager>().FindObjsInStep(stepNow);
        // Debug.Log(objsAtStep.Length);

    }


    public void chengeStep(int stepNow)
    {
        gameObject.GetComponent<PziLogic>().Step = stepNow;


        

        if (stepNow != 0) {
            ChangeColorStepItemToDefault(stepNow - 1);
        }
        if (stepNow < StepsCount-1)
        {
            Debug.Log(stepNow);
            ChangeColorStepItemToDefault(stepNow + 1);
            Debug.Log(stepNow);
        }
            

        ColoringObjAtStep(stepNow);

        ControlPanel.Instance.DestroyAllChilds();
        FindAllControllObjAndUNcheked();
        controlStepAnswer.Clear();
        AllAnswersAtMonitor.Clear();


        if (checkStepType() == 0)
        {
            controlStepFlag = true;
        }
        else
        {
            controlStepFlag = false;
        }


        if (checkStepType() == 0)
        {


            NextBotton.SetActive(true);
            if (Etap == 3)
            {
                promtTextChanger.Instance.ChangeText(0);
                ChangeNextButtonText(ThirdEtapString, true);
            }
            else
            {
                ChangeColorStepItem(stepNow);
                promtTextChanger.Instance.ChangeText(1);
                ChangeNextButtonText(ControlString, true);

            }


        }

        if (checkStepType() == 1)
        {


            if (Etap == 3)
            {
                promtTextChanger.Instance.ChangeText(2);
                ChangeNextButtonText(ThirdEtapString, true);
            }
            else
            {
                ChangeColorStepItem(stepNow);
                promtTextChanger.Instance.ChangeText(3);
                ChangeNextButtonText(ActionString, true);
            }

            NextBotton.SetActive(true);

        }
        if (checkStepType() == 2)
        {



            if (Etap != 3)
            {
                NextBotton.SetActive(false);
                promtTextChanger.Instance.ChangeText(4);
                ChangeColorStepItem(stepNow);
            }

            if (Etap == 3)
            {
                promtTextChanger.Instance.ChangeText(5);
                Debug.Log("chengeStep");
                ChangeNextButtonText(ThirdEtapString, true);
            }


        }



        Step = stepNow;
        changeText(stepNow);
        //Debug.Log("Step now --- " + stepNow + " Parent --- " + PziPrefab.GetComponent<xmlManager>().PZI.Steps[stepNow].ParentName);

        sleepBeforeActivate();

        if (Etap != 3)
        {
            PziPrefab.GetComponent<xmlManager>().PZI.Steps[stepNow].ObjForStep[0].ObjParent.SetActive(true);
        }

    }



    public void ChangeColorStepItem(int step)
    {


        foreach (var Item in PziPrefab.GetComponent<xmlManager>().PZI.Steps[step].ObjForStep)
        {

            Color newColor = new Color(0.0f, 0.75f, 1.0f, 1.0f);
            Item.Obj.GetComponent<Image>().DOColor(newColor, 0.25f);


        }



    }

    public void ChangeColorStepItemToDefault(int step)
    {


        foreach (var Item in PziPrefab.GetComponent<xmlManager>().PZI.Steps[step].ObjForStep)
        {

            Color newColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Item.Obj.GetComponent<Image>().DOColor(newColor, 0.25f);


        }



    }


    public void NextButtonAction()
    {

        //Debug.Log(PziName + " " + Step);




        switch (Etap)
        {
            case 1:



                NextStep();

                break;



            default:

                if (checkStepType() == 0) // control 2-3 etap
                {
                    int controlCount = PziPrefab.GetComponent<xmlManager>().PZI.Steps[Step].ObjForStep.Count;
                    int currControlCount = 0;
                    // Debug.Log("Stert CONTROL");


                    foreach (var Item in PziPrefab.GetComponent<xmlManager>().PZI.Steps[Step].ObjForStep)
                    {
                        //Debug.Log(PziPrefab.GetComponent<xmlManager>().PZI.Steps[Step].ObjForStep.Count);

                        for (int i = 0; i < controlStepAnswer.Count; i++)
                        {
                            //Debug.Log(controlStepAnswer[i].ElementName);
                            //Debug.Log("have --- "+Item.ObjName);

                            if (Item.ObjName == controlStepAnswer[i].ElementName)
                            {
                                //Debug.Log("found --- " + Item.ObjName);
                                //Debug.Log("controlStepAnswer --- " + controlStepAnswer[i].ElementName);

                                if (controlStepAnswer[i].BlockAtControlAnswer == Item.ObjParent)
                                {

                                    currControlCount++;

                                }

                            }

                        }




                    }

                    if ((controlCount == currControlCount) && (controlStepAnswer.Count == controlCount))
                    {


                        NextStep();



                    }
                    else
                    {

                        INFO.LoadInfoBox("#06 wrong number of monitored objects");
                        Debug.Log("#06 wrong number of monitored objects");
                    }

                    //Debug.Log("count --- " + controlCount + "   total ---" + currControlCount + "    cheked --- " + controlStepAnswer.Count);


                }

                else if (checkStepType() == 1)
                { // action 2-3 etap

                    if (PziPrefab.GetComponent<xmlManager>().PZI.Steps[Step].ObjForStep[0].ObjParent.name == blockAnswer)
                    {
                        NextStep();

                    }
                    else
                    {

                        INFO.LoadInfoBox("#05 Wrong Block on monitor at action step");

                    }


                }


                break;


        }









    }

    // element from block sent click here
    public void ElementSended(GameObject Block, GameObject Element, String Description, bool isDown)
    {
        if (isDown)
        {
            AddElement(Element);
            //Debug.Log(isDown);
        }
        else
        {
            DelElement(Element);

        }

        //Debug.Log("Block - " + Block.name + " Element - " + Element + " Desc - " + Description);
        //Debug.Log("controlStepFlag -" + controlStepFlag);
        blockAnswer = Block.name;
        if (!controlStepFlag)
        {
            ellementAnswer = Element.name;

        }
        else
        {
            //Debug.Log("here spot for adding control answer");
            if (isDown)
            {
                AddControlElement(Element, Description, Block);
            }
            else
            {
                DelControlElement(Element);
                ControlPanel.Instance.delinstance(Element, Block);
            }

        }

        ChangeNextButtonText(Description, false);


    }

    public void ChangeNextButtonText(string txt, bool startStep)
    {

        switch (Etap)
        {

            case 1:

                if (checkStepType() == 0)
                {

                    NextBotton.GetComponentInChildren<Text>().text = ControlString;
                    Debug.Log("checkStepType --- " + checkStepType());


                }
                if (checkStepType() == 1)
                {

                    NextBotton.GetComponentInChildren<Text>().text = ActionString;
                }


                break;



            case 2:
                if (checkStepType() == 0)
                {
                    if (startStep)
                    {

                        NextBotton.GetComponentInChildren<Text>().text = ControlString;
                    }
                    else
                    {

                        NextBotton.GetComponentInChildren<Text>().text = ControlString + txt;
                    }


                }
                if (checkStepType() == 1)
                {

                    if (startStep)
                    {
                        NextBotton.GetComponentInChildren<Text>().text = ActionString;
                    }
                    else
                    {
                        NextBotton.GetComponentInChildren<Text>().text = ActionString + txt;


                    }




                }
                break;

            case 3:

                if (startStep)
                {
                    NextBotton.GetComponentInChildren<Text>().text = ThirdEtapString;
                }
                else
                {
                    NextBotton.GetComponentInChildren<Text>().text = ThirdEtapString + txt;


                }


                break;

        }
    }

    private int checkStepType()
    {
        return Convert.ToInt32(PziPrefab.GetComponent<xmlManager>().PZI.Steps[Step].TypeOfAnswer);

    }



    public void sleepBeforeActivate()
    {
        GameObject[] gameObjectBlocksForSleep = GameObject.FindGameObjectsWithTag("blocks");
        //Debug.Log("sleepBeforeActivate");
        // вместо for можно использовать for (var go in gameObjects) 
        for (int i = 0; i < gameObjectBlocksForSleep.Length; ++i)
        {
            gameObjectBlocksForSleep[i].SetActive(false);
            //Debug.Log("just setActive -- false for all blocks");
        }
    }



}
