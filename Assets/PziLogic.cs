using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataFromXML;
using DataFromArduino;
using System;

public class PziLogic : MonoBehaviour
{



    private string pziName;
    public int Step;

    private List<string> AllStringToSend = new List<string>();

    private void OnEnable()
    {
        pziName = PracticalLessonNumber.LessonNumber;
        // Debug.Log("pziName on Enable-- " + pziName);

    }

    IEnumerator SendStringsToArduino()
    {
        Debug.Log(AllStringToSend[0]);
        foreach (string Item in AllStringToSend)
        {

            sendToArduino(Item);
            Debug.Log("send --- " + Item);
            yield return new WaitForSeconds(0.02f);
        }
        AllStringToSend.Clear();


    }

    IEnumerator LampWait_4s()
    {
        Debug.Log(AllStringToSend[0]);
        foreach (string Item in AllStringToSend)
        {

            sendToArduino(Item);
            yield return new WaitForSeconds(4.0f);
        }
        AllStringToSend.Clear();


    }

    IEnumerator lamp28_on_off()
    {


        {
            yield return new WaitForSeconds(0.1f);
            sendToArduino("on27");
            yield return new WaitForSeconds(3.0f);
            sendToArduino("off27");
        }



    }

    IEnumerator lamp9_10_flashing()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on8");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on9");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off8");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off9");
            yield return new WaitForSeconds(1.0f);
        }



    }

    IEnumerator lamp_3_3_3_13()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            sendToArduino("on0");
            yield return new WaitForSeconds(0.5f);
            sendToArduino("off0");
        }



    }

    private bool _lamp_3_3_3_13_bool;
    private Coroutine _coroutine;


    IEnumerator Lamp0_flashing_2600()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off0");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("on0");
            yield return new WaitForSeconds(1.0f);
        }



    }

    IEnumerator YellowLampSAS_flashing()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on2");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on3");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off2");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off3");
            yield return new WaitForSeconds(1.0f);
        }



    }

    public void StartStepFunction(string pziName, int step)
    {

        //Debug.Log(pziName);

        try
        {
            Invoke(pziName, 0.5f);
            Step = step;

        }
        catch
        {

            Debug.Log("NO function at Step " + Step);

        }


    }

    private void sendToArduino(string StringToSend)
    {

        GameObject arduinoMenager = GameObject.FindGameObjectWithTag("Arduino");
        //Debug.Log(arduinoMenager);
        arduinoMenager.GetComponent<DevicesManager>().SendToDevice(StringToSend, 0);
        //

    }

    public void ArduinoAction(string[] StrFromArduino)
    {
        if (StrFromArduino[2].Contains("."))
        {
            StrFromArduino[2] = Convert.ToInt32(StrFromArduino[2].Substring(0, StrFromArduino[2].IndexOf("."))).ToString();
        }

        switch (pziName)
        {
            case "LM2D2T7PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off31");


                                        break;



                                }

                                break;


                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 3)
                                            sendToArduino("on10");

                                        break;






                                }

                                break;

                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":
                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;


                                }




                                break;



                        }


                        break;



                }


                break;



            case "LM2D2T6PZI1":

                switch (StrFromArduino[0])
                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 4)
                                        {
                                            sendToArduino("on0");
                                        }
                                        break;



                                }


                                break;
                        }







                        break;

                }


                break;

            case "LM2D2T6PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "5":
                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("off16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }




                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;



                }


                break;


            case "LM2D2T6PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "2":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "7":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "11":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on17");
                                            AllStringToSend.Add("on22");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                }




                                break;



                        }


                        break;

                }


                break;


            case "LM2D2T6PZI4":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on28");
                                            AllStringToSend.Add("on26");
                                            AllStringToSend.Add("on29");
                                            AllStringToSend.Add("on30");
                                            AllStringToSend.Add("on31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("off30");
                                            AllStringToSend.Add("off31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 24)
                                        {
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 27)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on26");
                                            AllStringToSend.Add("on28");
                                            AllStringToSend.Add("on29");
                                            AllStringToSend.Add("on30");
                                            AllStringToSend.Add("on31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 25)
                                        {
                                            sendToArduino("on32");
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 25)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("off27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    default:

                                        sendToArduino("off32");


                                        break;



                                }


                                break;





                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "1":
                                switch (StrFromArduino[2])

                                {

                                    case "8":

                                        if (Step == 7)
                                        {
                                            StartCoroutine(lamp28_on_off());
                                        }



                                        break;


                                }




                                break;



                        }


                        break;

                }


                break;


            case "LM2D2T6PZI5":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "6":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;



                                }


                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 31)
                                        {
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "3":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "4":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 36)
                                        {

                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;


                                }




                                break;



                        }


                        break;

                }


                break;

            case "LM2D2T6PZI6":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 27)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }


                                break;





                        }


                        break;

                }


                break;


            case "LM2D2T6PZI7":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "1":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "3":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "4":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "5":

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "6":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "7":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "8":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;


                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "3":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "6":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                }


                                break;



                        }


                        break;

                }


                break;

            case "LM2D2T6PZI8":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 9)
                                        {
                                            sendToArduino("on11");
                                        }

                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(lamp28_on_off());

                                        break;

                                    default:



                                        break;



                                }


                                break;


                        }


                        break;




                }


                break;

            case "LM2D2T6PZI9":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on11");

                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(lamp28_on_off());

                                        break;

                                    case "2":

                                        AllStringToSend.Add("on3");
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("on5");
                                        StartCoroutine(SendStringsToArduino());
                                        StartCoroutine(lamp28_on_off());

                                        break;



                                }

                                break;






                        }


                        break;


                }


                break;

            case "LM2D2T6PZI10":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 3)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;

            case "LM2D2T6PZI11":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 12)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;

            case "LM2D2T6PZI12":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 11)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;


            case "LM2D2T6PZI13":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 11)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;


            case "LM2D2T6PZI14":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;



                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "3":
                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "4":
                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "5":
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "6":
                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "7":
                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "8":
                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "0":
                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                }

                                break;






                        }


                        break;

                }


                break;

            case "LM2D2T6PZI15":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off21");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step > 29)
                                        {
                                            sendToArduino("off21");
                                        }


                                        break;

                                    case "0":

                                        sendToArduino("on21");


                                        break;


                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on19");


                                        break;

                                    default:

                                        AllStringToSend.Add("off18");
                                        AllStringToSend.Add("off19");
                                        StartCoroutine(SendStringsToArduino());


                                        break;



                                }


                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on18");


                                        break;

                                    default:

                                        sendToArduino("off18");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on32");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "0":

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off32");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;


                                }


                                break;


                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("s3goto50");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("s3goto0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("on21");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 24)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 28)
                                        {
                                            sendToArduino("on29");
                                        }

                                        break;

                                    case "5":

                                        if (Step == 32)
                                        {
                                            sendToArduino("on30");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 36)
                                        {
                                            sendToArduino("on31");
                                        }

                                        break;

                                }

                                break;




                        }


                        break;


                }


                break;

            case "LM2D2T7PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":
                                // Debug.Log("ddddddddddddddddddd"); // Приходит
                                switch (StrFromArduino[2])

                                {

                                    case "12":

                                        Debug.Log("ddddddddddddddddddd"); // Не приходит :(
                                        sendToArduino("on22");

                                        break;

                                    case "13":


                                        AllStringToSend.Add("off22");
                                        AllStringToSend.Add("on23");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "14":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("off23");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "15":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "16":

                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "17":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "18":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "19":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "20":

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM2D2T7PZI4":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on7");
                                        AllStringToSend.Add("on31");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on20");

                                        break;

                                    default:

                                        sendToArduino("off20");

                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on8");

                                        break;

                                    default:

                                        sendToArduino("off8");

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("on10");
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;


                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("on10");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "10":

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on13");
                                            AllStringToSend.Add("on17");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "18":

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off17");
                                            AllStringToSend.Add("on18");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "20":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM2D2T7PZI5":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on20");
                                        AllStringToSend.Add("on31");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on21");

                                        break;

                                    default:

                                        sendToArduino("off21");

                                        break;


                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;

                                    default:

                                        sendToArduino("on20");

                                        break;


                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on22");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off22");
                                            AllStringToSend.Add("on23");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;


                        }

                        break;

                }

                break;

            case "LM2D2T7PZI7":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on9");
                                        break;

                                    default:

                                        sendToArduino("off10");


                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI8":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on9");

                                        break;

                                    default:

                                        sendToArduino("off9");

                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI9":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;


                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        sendToArduino("on0");

                                        break;

                                    default:

                                        sendToArduino("off0");

                                        break;



                                }

                                break;






                        }

                        break;


                }


                break;

            case "LM2D2T7PZI11":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on19");
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI12":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on20");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                        }

                        break;



                }


                break;

            case "LM2D2T7PZI13":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");
                                        StopCoroutine(lamp9_10_flashing());

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            StartCoroutine(lamp9_10_flashing());
                                        }

                                        break;



                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM2D2T7PZI14":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on31");
                                        AllStringToSend.Add("on7");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on");

                                        break;

                                    default:

                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("on7");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 26)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 32)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 37)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 42)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on4");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        break;



                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 28)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 34)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 39)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 44)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off4");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;



                }


                break;

            case "LM2D2T7PZI15":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 3)
                                        {
                                            sendToArduino("on10");
                                        }

                                        break;



                                }

                                break;




                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on11");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "2":
                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "3":
                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "4":
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "5":
                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "6":
                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "7":
                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on17");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "8":
                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off17");
                                            AllStringToSend.Add("on18");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "9":
                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off18");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "10":
                                        if (Step == 24)
                                        {
                                            AllStringToSend.Add("off19");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "11":
                                        if (Step == 26)
                                        {
                                            AllStringToSend.Add("off20");
                                            AllStringToSend.Add("on21");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "12":
                                        if (Step == 28)
                                        {
                                            AllStringToSend.Add("off21");
                                            AllStringToSend.Add("on22");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "13":
                                        if (Step == 30)
                                        {
                                            AllStringToSend.Add("off22");
                                            AllStringToSend.Add("on23");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "14":
                                        if (Step == 32)
                                        {
                                            AllStringToSend.Add("off23");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "15":
                                        if (Step == 34)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "16":
                                        if (Step == 36)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "17":
                                        if (Step == 38)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "18":
                                        if (Step == 40)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "20":
                                        if (Step == 42)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        if (Step == 47)
                                        {
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "19":
                                        if (Step == 44)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;


                                }

                                break;






                        }


                        break;


                }


                break;

            case "LM2D2T8PZI1":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "3":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on3");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("s0goto76");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "1":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }

                                break;


                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 4)
                                        {
                                            sendToArduino("s0goto46");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto106");
                                        }

                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 5)
                                        {
                                            sendToArduino("s0goto38");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 8)
                                        {
                                            sendToArduino("s0goto114");
                                        }

                                        break;


                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM3D5T8PZI6":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "5":

                                        if (Step == 7)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "4":

                                        if (Step == 8)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 16)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;




                        }

                        break;

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(Lamp0_flashing_2600());

                                        break;

                                    case "0":

                                        StopCoroutine(Lamp0_flashing_2600());

                                        break;


                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM3D2T5PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on17");

                                        break;

                                    default:

                                        sendToArduino("off");
                                        StopCoroutine(YellowLampSAS_flashing());

                                        break;



                                }

                                break;




                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "9":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(YellowLampSAS_flashing());
                                        }

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on11");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "1":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "7":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "8":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on9");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;




                        }

                        break;


                }


                break;

            case "LM3D2T5PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on17");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "9":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "8":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on9");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;


                }


                break;



            case "LM3D3T3PZI1":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("s0goto110");
                                            AllStringToSend.Add("s1goto70");
                                        }

                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");


                                        StartCoroutine(SendStringsToArduino());

                                        break;



                                }

                                break;



                        }

                        break;




                }


                break;



            case "LM3D3T3PZI11":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;



                                }

                                break;



                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (Convert.ToInt32(StrFromArduino[2]))

                                {

                                    case 0:

                                        sendToArduino("s0goto18");
                                        break;

                                    case 1:


                                        sendToArduino("s0goto110");
                                        Debug.Log("StrFromArduino[2] --- " + StrFromArduino[2]);

                                        break;

                                    default:

                                        Debug.Log("StrFromArduino[2] --- " + StrFromArduino[2]);

                                        break;



                                }

                                break;



                        }

                        break;


                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    default:


                                        if (Convert.ToInt32(StrFromArduino[2]) > 950)
                                        {

                                            if (Step == 7)
                                            {

                                                AllStringToSend.Add("on0");
                                                AllStringToSend.Add("on1");
                                                AllStringToSend.Add("s0goto11");



                                                StartCoroutine(SendStringsToArduino());
                                            }

                                        }








                                        break;



                                }

                                break;



                        }

                        break;




                }


                break;




            case "LM3D3T3PZI12":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;



                                }

                                break;



                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "0":
                                        sendToArduino("on2");
                                        break;

                                    case "2":
                                        sendToArduino("off2");
                                        break;






                                }

                                break;


                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        sendToArduino("s1goto45");
                                        break;

                                    case "0":
                                        sendToArduino("s1goto70");
                                        break;

                                }

                                break;



                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (Convert.ToInt32(StrFromArduino[2]))

                                {

                                    case 1:

                                        sendToArduino("s0goto110");

                                        break;

                                    case 2:


                                        sendToArduino("s0goto0");


                                        break;

                                    case 4:


                                        sendToArduino("s0goto130");


                                        break;





                                }

                                break;



                        }

                        break;



                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    default:


                                        //if (Convert.ToInt32(StrFromArduino[2]) > 950)


                                        if (Step == 4 || Step == 6)
                                        {

                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));


                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));

                                            // StartCoroutine(SendStringsToArduino());
                                        }


                                        if (Step == 21)
                                        {


                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 480, 0, 98));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 480, 0, 98));




                                            //StartCoroutine(SendStringsToArduino());
                                        }










                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    default:

                                        if (Step == 22)
                                        {

                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;



                        }

                        break;




                }


                break;


            case "LM3D3T3PZI13":


                switch (StrFromArduino[0])
                {
                    case "t":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (StrFromArduino[2])

                                {
                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;


                    case "e":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (Convert.ToInt32(StrFromArduino[2]))
                                {
                                    case 1:
                                        sendToArduino("s0goto110");
                                        break;
                                    case 2:
                                        sendToArduino("s0goto0");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])
                                {
                                    default:

                                        if (Step == 5)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            // StartCoroutine(SendStringsToArduino());
                                        }
                                        break;
                                }
                                break;
                            case "1":
                                switch (StrFromArduino[2])
                                {
                                    default:
                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            // StartCoroutine(SendStringsToArduino());
                                            if (Convert.ToInt32(StrFromArduino[2]) > 450)
                                            {
                                                if (!_lamp_3_3_3_13_bool)
                                                {
                                                    _coroutine = StartCoroutine(lamp_3_3_3_13());

                                                    _lamp_3_3_3_13_bool = true;
                                                }

                                            }




                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                }
                break;


            case "LM3D3T3PZI14":


                switch (StrFromArduino[0])
                {
                    case "t":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (StrFromArduino[2])

                                {
                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;


                    case "e":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (Convert.ToInt32(StrFromArduino[2]))
                                {

                                    case 2:
                                        sendToArduino("s0goto0");
                                        break;
                                }
                                break;
                        }
                        break;



                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])
                                {
                                    default:

                                        if (Step == 3)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 700, 0, 138));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 11)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 200, 700, 42, 138));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 19)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 200, 500, 42, 98));
                                            // StartCoroutine(SendStringsToArduino());
                                        }
                                        break;
                                }
                                break;

                            case "1":
                                switch (StrFromArduino[2])
                                {
                                    default:
                                        if (Step == 4)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 0, 4) + 138));

                                        }
                                        if (Step == 12)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, -4, 0) + 42));

                                        }
                                        if (Step == 20)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 0, 4) + 98));

                                        }
                                        break;




                                }
                                break;
                        }
                        break;

                }
                break;


            case "LM3D3T3PZI4":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        AllStringToSend.Add("on1");
                                        AllStringToSend.Add("on3");
                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off3");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;

                }
                break;


            case "LM3D3T3PZI5":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "9":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2044");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;

                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    default:


                                        sendToArduino("mon" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 2044, 2024));

                                        break;
                                }
                                break;
                        }
                        break;

                }
                break;

            case "LM3D3T3PZI6":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2021");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI7":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":

                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:

                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2021");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;

                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    default:


                                        sendToArduino("mon" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 2021, 2018));

                                        break;
                                }
                                break;
                        }
                        break;



                }
                break;

            case "LM3D3T3PZI8":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {

                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon0960");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI9":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {

                            case "10":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon-2560");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI10":


                switch (StrFromArduino[0])
                {
                    
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon00900");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":

                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:

                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                            
                        }
                        break;


                }
                break;



        }






    }


    private float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


    public void LM3D3T3PZI14()
    {
        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }
    }
    public void LM3D3T3PZI13()
    {
        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }
        if (Step == 16)
        {
            StopCoroutine(_coroutine);
        }
    }
    public void LM3D3T3PZI12()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }



    }
    public void LM3D3T3PZI11()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }



    }
    public void LM3D3T3PZI1()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }


        if (Step == 17)
        {
            sendToArduino("s1goto65");
        }

    }
    public void LM2D2T6PZI1()
    {

        if (Step == 10)
        {
            sendToArduino("off0");
        }

        if (Step == 12)
        {
            sendToArduino("on0");
        }

        if (Step == 17)
        {
            AllStringToSend.Add("off0");
            AllStringToSend.Add("on1");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            AllStringToSend.Add("off1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 23)
        {
            AllStringToSend.Add("off2");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on15");
            AllStringToSend.Add("s3goto353");
            StartCoroutine(SendStringsToArduino());
        }

    }
    public void LM2D2T6PZI2()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto353");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }


        if (Step == 1)
        {
            AllStringToSend.Add("s3goto404");
            AllStringToSend.Add("off7");
            AllStringToSend.Add("off13");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("on14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            AllStringToSend.Add("s3goto702");
            AllStringToSend.Add("off8");
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on11");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off11");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("on12");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 10)
        {
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on14");
            AllStringToSend.Add("on15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

    }
    public void LM2D2T6PZI5()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI6()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("on0");
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("on9");
            AllStringToSend.Add("on10");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI7()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI8()
    {
        if (Step == 14)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 19)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }



    }
    public void LM2D2T6PZI9()
    {

        if (Step == 13)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 20)
        {
            sendToArduino("s3goto150");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI10()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto702");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            sendToArduino("s3goto0");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 11)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 15)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto251");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 19)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 23)
        {
            sendToArduino("s3goto702");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI11()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 8)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 13)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto302");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 22)
        {
            sendToArduino("s3goto453");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 27)
        {
            sendToArduino("s3goto601");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI12()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto302");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 16)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 21)
        {
            sendToArduino("s3goto452");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 26)
        {
            sendToArduino("s3goto602");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI13()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto201");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto353");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto453");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 22)
        {
            sendToArduino("s3goto652");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI14()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            sendToArduino("s3goto0");
        }


    }
    public void LM2D2T6PZI15()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI3()
    {

        if (Step == 0)
        {
            sendToArduino("on31");
        }


    }
    public void LM2D2T7PZI7()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI8()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI9()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("on7");
            StartCoroutine(LampWait_4s());
        }

    }
    public void LM2D2T7PZI11()
    {

        if (Step == 0)
        {
            sendToArduino("on31");
        }

        if (Step == 4)
        {
            AllStringToSend.Add("off19");
            AllStringToSend.Add("on10");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 6)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 8)
        {
            sendToArduino("on10");
        }

        if (Step == 10)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("off11");
            AllStringToSend.Add("on12");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 12)
        {
            sendToArduino("on10");
        }

        if (Step == 14)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 16)
        {
            sendToArduino("on10");
        }

        if (Step == 18)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("off11");
            AllStringToSend.Add("off12");
            AllStringToSend.Add("on13");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            sendToArduino("on10");
        }

        if (Step == 22)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 24)
        {
            sendToArduino("on10");
        }

    }
    public void LM2D2T7PZI12()
    {

        if (Step == 8)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 10)
        {
            sendToArduino("on14");
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 14)
        {
            sendToArduino("on14");
        }

        if (Step == 16)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 18)
        {
            sendToArduino("on14");
        }

        if (Step == 20)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("on17");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 22)
        {
            sendToArduino("on14");
        }

        if (Step == 24)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 26)
        {
            sendToArduino("on14");
        }

        if (Step == 28)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 30)
        {
            sendToArduino("on14");
        }

        if (Step == 32)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 34)
        {
            sendToArduino("on14");
        }

        if (Step == 36)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("off17");
            AllStringToSend.Add("on18");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 38)
        {
            sendToArduino("on14");
        }

        if (Step == 40)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 42)
        {
            sendToArduino("on14");
        }

        if (Step == 44)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 46)
        {
            sendToArduino("on14");
        }


    }
    public void LM2D2T7PZI13()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            AllStringToSend.Add("on7");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T8PZI1()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto76");
        }

        if (Step == 1)
        {
            sendToArduino("on4");
        }

    }
    public void LM2D2T8PZI2()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto76");
        }

        if (Step == 3)
        {
            sendToArduino("on4");
        }

        if (Step == 5)
        {
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on3");
            AllStringToSend.Add("s0goto122");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 9)
        {
            AllStringToSend.Add("off1");
            AllStringToSend.Add("off3");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("on0");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("s0goto30");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 16)
        {
            AllStringToSend.Add("off0");
            AllStringToSend.Add("off2");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM3D5T8PZI6()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto76");
        }

        if (Step == 6)
        {
            AllStringToSend.Add("on4");
            AllStringToSend.Add("on0");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            sendToArduino("off4");
        }

    }


}